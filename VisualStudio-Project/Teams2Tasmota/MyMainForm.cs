﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Net;
using System.Xml.Linq;

namespace Teams2Tasmota
{
    public partial class MainForm : Form
    {
        string logFileName;
        int line_counter = 0;
        long file_size = 0;
        string url;

        // hide x-Button on MainForm
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle |=  CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //constructor
        public MainForm()
        {
            InitializeComponent();

            listView1.View = View.Details;

            ReadMyXML(true);

            if(logFileName.StartsWith(@"%AppData%"))
                logFileName = logFileName.Replace(@"%AppData%",Environment.GetEnvironmentVariable("AppData"));

            if (!File.Exists(logFileName))
            {
                Console.WriteLine("File does not exist.");
                var openFileDialog = new OpenFileDialog() {
                    CheckFileExists = true,
                    Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                    FilterIndex = 1,
                    Title = "Please select MS-Teams Logdfile",
                    InitialDirectory = Environment.GetEnvironmentVariable("AppData") + @"\Microsoft\Teams\"                    
                };
                openFileDialog.CustomPlaces.Add(Environment.GetEnvironmentVariable("AppData"));
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    logFileName = openFileDialog.FileName;
                }
                else System.Windows.Forms.Application.Exit();
            }

        }

        //read config.xml to global variables
        private void ReadMyXML(bool onStartup = false)
        {
            XDocument doc = XDocument.Load("config.xml");
            serialPort1.PortName = doc.Element("Settings").Element("ComPort").FirstAttribute.Value.ToString();
            url = doc.Element("Settings").Element("URL").FirstAttribute.Value.ToString();

            if (onStartup)
            {
                minimize_timer.Enabled = Convert.ToBoolean(doc.Element("Settings").Element("Minimize").FirstAttribute.Value);
                file_size = Convert.ToInt64(doc.Root.Element("LogFile").Attribute("Size").Value);
                file_size -= 50000;
                if (file_size < 0) file_size = 0;

                logFileName = doc.Root.Element("LogFile").Attribute("FileName").Value;
            }

            //populate ListView with xml Content
            listView1.Items.Clear();
            foreach (XElement el in doc.Root.Elements())
            {
                if (el.Attribute("status")!=null)
                {
                    ListViewItem item1 = new ListViewItem(el.Attribute("status").Value);
                    item1.SubItems.Add(el.Attribute("CMD").Value);
                    item1.SubItems.Add("");
                    item1.SubItems.Add("");
                    listView1.Items.Add(item1);
                }
            }
        }

        //write ListView strings to xml
        private void ListView2xml()
        {
            XDocument doc = XDocument.Load("config.xml");
            while (doc.Root.Element("Line")!=null) { 
                doc.Root.Element("Line").Remove();
            }
            
            foreach (ListViewItem LVItem in listView1.Items)
            {
                doc.Root.Add(new XElement("Line", new XAttribute("status", LVItem.Text), new XAttribute("CMD", LVItem.SubItems[1].Text)));
            }
            doc.Save("config.xml");
        }

        private void CheckLogFileChanged()
        {
            string line;
            string last_State = "";
            MethodInvoker LabelUpdate = delegate
            {
                if(!System.IO.File.Exists(logFileName))return;
                System.IO.FileStream file_stream = new FileStream(logFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                System.IO.StreamReader file = new System.IO.StreamReader(file_stream);
                if (file_size > file.BaseStream.Length)
                {
                    LogTextBox.Text = "";
                    file_size = 0;
                    line_counter = 0;
                }
                if (file_size < file.BaseStream.Length)
                {
                    file.BaseStream.Seek(file_size, SeekOrigin.Begin);
                    file_size = file.BaseStream.Length;
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("StatusIndicatorStateService:"))
                        {
                            string search_string = " Added ";
                            int x = line.IndexOf(search_string);
                            if (x >= 0)
                            {
                                int y = line.IndexOf(' ', x + search_string.Length);    //Serach for the Word after search_text
                                if (y >= 0)
                                {
                                    last_State = line.Substring(x + search_string.Length, y-x- search_string.Length).Trim();
                                    line = line.Insert(y, @"\b0 ");
                                    line = line.Insert(x, @"\b ");
                                }
                            }
                            //StatusIndicatorStateService: Removing ConnectionError (current state: ConnectionError -> Away) 
                            search_string = " Removing ";
                            x = line.IndexOf(search_string);
                            if (x >= 0)
                            {
                                int y = line.LastIndexOf(" -> ");    //Serach for the Word after " -> "
                                if (y >= 0)
                                {
                                    char[] MyChar = { ')', ' ' };
                                    last_State = line.Substring(y+4).TrimEnd(MyChar);
                                    line = line.Insert(y+line.Substring(y).IndexOf(')'), @"\b0 ");
                                    line = line.Insert(y+4, @"\b ");
                                    line = line.Insert(x+search_string.Length, @"\b0 ");
                                    line = line.Insert(x, @"\b ");
                                }
                            }

                            LogTextBox.SelectionStart = LogTextBox.Text.Length;
                            LogTextBox.SelectedRtf = @"{\rtf1\ansi " + line + @"\line}";
                            if (LogTextBox.Visible) // scroll to the end
                            {
                                LogTextBox.SelectionStart = LogTextBox.TextLength;
                                LogTextBox.ScrollToCaret();
                            }
                        }
                        line_counter++;
                    }
                    file.Close();
                    toolStripLinesLabel.Text = line_counter.ToString();
                    if (last_State != "")
                    {
                        toolStripStatusLabel.Text = last_State;
                        notifyIcon1.Text = "Teams2Tasmota - " + last_State;

                        AktStatusChanged();
                    }
                }
            };
            try
            {
                Invoke(LabelUpdate);
            }
            catch { }
        }

        string MyWebRequest(string url)
        {
            string status = "";
            try
            {
                if (url == "") return ("");
                url = url.Replace(" ", "%20");
                string responseFromServer = "";
                // Create a request using a URL that can receive a post.
                WebRequest request = WebRequest.Create(url);
                // Set the Method property of the request to POST.
                request.Method = "POST";
                request.Timeout = 1000;

                // Create POST data and convert it to a byte array.
                string postData = "This is a test that posts this string to a Web server.";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);

                // Set the ContentType & length property of the WebRequest.
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;

                // Get the request stream & write the data to it.
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();

                // Get the response.
                WebResponse response = request.GetResponse();
                status = ((HttpWebResponse)response).StatusDescription;
                // Display the status.
                //Console.WriteLine(((HttpWebResponse)response).StatusDescription);

                // Get the stream containing content returned by the server.
                // The using block ensures the stream is automatically closed.
                using (dataStream = response.GetResponseStream())
                {
                    // Open the stream using a StreamReader for easy access.
                    StreamReader reader = new StreamReader(dataStream);
                    // Read the content.
                    responseFromServer = reader.ReadToEnd();
                }

                // Close the response.
                response.Close();
                return (status + " "+ responseFromServer);
            }
            catch(WebException e){ 
                return (status + " " + "WebRequest Error" +e.Message);
            }
            catch{
                return (status + " " + "WebRequest Error");
            }
        }

        private void AktStatusChanged()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Text == toolStripStatusLabel.Text)
                {
                    DateTime dateNow = DateTime.Now;
                    item.Selected = true;
                    try
                    {
                        var x = listView1.SelectedItems[0].SubItems[1].Text; //Color AABBCC  Convert.ToByte(localText.Substring(6, 2), 16)
                        toolStripStatusLabelColor.BackColor = Color.FromArgb(Convert.ToByte(x.Substring(6, 2), 16), Convert.ToByte(x.Substring(8, 2), 16), Convert.ToByte(x.Substring(10, 2), 16));
                    }
                    catch { }
                    try
                    {
                        serialPort1.Open();
                        serialPort1.WriteLine(item.SubItems[1].Text);
                        item.SubItems[2].Text = serialPort1.ReadLine();
                        item.SubItems[3].Text = dateNow.ToLocalTime().ToString();
                       
                    }
                    catch
                    {
                        item.SubItems[2].Text = MyWebRequest(url + @"/cm?cmnd=" + item.SubItems[1].Text);
                        item.SubItems[3].Text = dateNow.ToLocalTime().ToString();
                    }
                    try
                    {
                        serialPort1.Close();
                    }
                    catch { }
                    break;
                }

            }
        }

        private void ListView_DoubleClick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = listView1.SelectedItems[0].SubItems[0].Text; ;
            AktStatusChanged();
        }

        private void SettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Dialog = new SettingsForm() {
                StartPosition = FormStartPosition.CenterParent
            };
            if (Dialog.ShowDialog(this)== DialogResult.OK)
            {
                ReadMyXML();
                //XDocument doc = XDocument.Load("config.xml");
                //serialPort1.PortName = doc.Element("Settings").Element("ComPort").FirstAttribute.Value.ToString();              
            }
            Dialog.Dispose();
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            //notifyIcon1.Visible = false;
        }

        private void OnTimer(object sender, EventArgs e)
        {
            CheckLogFileChanged();
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView1.FocusedItem.Bounds.Contains(e.Location))
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
            }
        }

        //minimize to tray after timer periode
        private void MinimizeTimerTick(object sender, EventArgs e)
        {
            minimize_timer.Enabled = false;
            Hide();
        }

        //scroll ListView to end
        private void LogTextBox_VisibleChanged(object sender, EventArgs e)
        {
            if (LogTextBox.Visible)
            {
                LogTextBox.SelectionStart = LogTextBox.TextLength;
                LogTextBox.ScrollToCaret();
            }
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var Dialog = new EditColorForm() {
                StartPosition = FormStartPosition.CenterParent,
                SerialPortName = serialPort1.PortName,
                url = url,
                ColorText = listView1.SelectedItems[0].SubItems[1].Text
            };
            if (Dialog.ShowDialog(this) == DialogResult.OK)
            {
                listView1.SelectedItems[0].SubItems[1].Text = Dialog.ColorText;
                ListView2xml();
            }
            Dialog.Dispose();

        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            //if the form is minimized  
            //hide it from the task bar  
            //and show the system tray icon (represented by the NotifyIcon control)  
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort1.Open();
                serialPort1.WriteLine("Power off");
            }
            catch
            {
                MyWebRequest(url + @"/cm?cmnd=Power off");
            }
            try
            {
                serialPort1.Close();
            }
            catch { }

            string logFileName_toSave = logFileName;
            if (logFileName.StartsWith(Environment.GetEnvironmentVariable("AppData")))
                logFileName_toSave = @"%AppData%" + logFileName.Substring(Environment.GetEnvironmentVariable("AppData").Length);
            
            XDocument doc = XDocument.Load("config.xml");
            doc.Element("Settings").Element("LogFile").ReplaceAttributes(new XAttribute("FileName", logFileName_toSave), new XAttribute("Size", file_size));
            doc.Save("config.xml");
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripStatusLabel5_Click(object sender, EventArgs e)
        {
            ToolStripLabel toolStripLabel1 = (ToolStripLabel)sender;

            System.Diagnostics.Process.Start(toolStripLabel1.Tag.ToString());

            // Set the LinkVisited property to true to change the color.
            toolStripLabel1.LinkVisited = true;
        }
    
    }
}

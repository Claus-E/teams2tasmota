using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace Teams2Tasmota
{
    public partial class EditColorForm : Form
    {        
        public string SerialPortName="COM1";
        public string url="";
        public string ColorText = "Color 000000";

        private void EditColorForm_Shown(object sender, EventArgs e)
        {
            serialPort1.PortName = SerialPortName;
            string localText = ColorText;
            try
            {
                trackBar1.Value = Convert.ToByte(localText.Substring(6, 2), 16);
                trackBar2.Value = Convert.ToByte(localText.Substring(8, 2), 16);
                trackBar3.Value = Convert.ToByte(localText.Substring(10, 2), 16);
                label1.Text = ColorText;
            }
            catch { }
        }

        public EditColorForm()
        {
            InitializeComponent();
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            
            ColorText = label1.Text = "Color " + trackBar1.Value.ToString("X2")+ trackBar2.Value.ToString("X2")+ trackBar3.Value.ToString("X2");
            panel4.BackColor= Color.FromArgb(trackBar1.Value, trackBar2.Value, trackBar3.Value);
            panel4.Update();

            try
            {
                serialPort1.Open();
                serialPort1.WriteLine(label1.Text);
            }
            catch
            {
                MyWebRequest(url + @"/cm?cmnd=" + label1.Text);
            }
            try
            {
                serialPort1.Close();
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
                return (status + " " + responseFromServer);
            }
            catch (WebException e)
            {
                return (status + " " + "WebRequest Error" + e.Message);
            }
            catch
            {
                return (status + " " + "WebRequest Error");
            }
        }

        private void noCommandButton_Click(object sender, EventArgs e)
        {
            ColorText = "";
            //this.Dispose();
            this.DialogResult = DialogResult.OK;
        }

        private void EditColorForm_Load(object sender, EventArgs e)
        {

        }
    }
}

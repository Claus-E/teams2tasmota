using System;
using System.Management;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Teams2Tasmota
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();


        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("config.xml");
            string comPort = doc.Element("Settings").Element("ComPort").Attribute("Name").Value.ToString();
            // Get all serial (COM)-ports you can see in the devicemanager
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\cimv2",
                "SELECT * FROM Win32_PnPEntity WHERE ClassGuid=\"{4d36e978-e325-11ce-bfc1-08002be10318}\"");

            // Sort the items in the combobox 
            cmbSerialPorts.Sorted = true;

            // Add all available (COM)-ports to the combobox
            cmbSerialPorts.Items.Add("---");
            cmbSerialPorts.SelectedIndex = 0;
            foreach (ManagementObject queryObj in searcher.Get()) {
                cmbSerialPorts.Items.Add(queryObj["Caption"]);
                if (queryObj["Caption"].ToString().IndexOf(comPort) >= 0)
                    cmbSerialPorts.SelectedIndex = cmbSerialPorts.FindString(queryObj["Caption"].ToString());
            }
            

            string baudrate = doc.Element("Settings").Element("ComPort").Attribute("Baudrate").Value.ToString();
            cbmSerialBaudrate.SelectedIndex = cbmSerialBaudrate.Items.IndexOf(baudrate);
            
            textBox1.Text = doc.Element("Settings").Element("URL").FirstAttribute.Value.ToString();

            new_teams_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("new").Attribute("Teams").Value);
            minimize_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Minimize").FirstAttribute.Value);
            notification_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onNotification").Value);
            chat_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onChat").Value);
            call_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onCall").Value);
            try
            {
                string encryptedPWD = doc.Element("Settings").Element("WebPassword").Value.ToString();
                webPasswordTextBox.Text = Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(encryptedPWD),null, DataProtectionScope.CurrentUser));
            }
            catch { }
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("config.xml");
            doc.Element("Settings").Element("Minimize").ReplaceAttributes(new XAttribute("afterStart",minimize_checkBox.Checked.ToString()));
            doc.Element("Settings").Element("Flash").ReplaceAttributes(
                new XAttribute("onNotification",notification_checkBox.Checked.ToString()),
                new XAttribute("onChat", chat_checkBox.Checked.ToString()),
                new XAttribute("onCall", call_checkBox.Checked.ToString()));
            doc.Element("Settings").Element("new").ReplaceAttributes(new XAttribute("Teams", new_teams_checkBox.Checked.ToString()));
            string comName = "---";
            // Set the right port for the selected item.
            // The portname is based on the "COMx" part of the string (SelectedItem)
            string item = cmbSerialPorts.SelectedItem.ToString();

            // Search for the expression "(COM" in the "selectedItem" string
            if (item.Contains("(COM"))
            {
                // Get the index number where "(COM" starts in the string
                int indexOfCom = item.IndexOf("(COM");

                // Set PortName to COMx based on the expression in the "selectedItem" string
                // It automatically gets the correct length of the COMx expression to make sure 
                // that also a COM10, COM11 and so on is working properly.
                comName = item.Substring(indexOfCom + 1, item.Length - indexOfCom - 2);
            }
            //doc.Element("Settings").Element("ComPort").ReplaceAttributes( new XAttribute("Name", comName ));
            string comBaudrate;
            comBaudrate = cbmSerialBaudrate.Text;
            doc.Element("Settings").Element("ComPort").ReplaceAttributes(new XAttribute("Name", comName),new XAttribute("Baudrate", comBaudrate));
            doc.Element("Settings").Element("URL").ReplaceAttributes(new XAttribute("Adress", textBox1.Text));

            string encryptedPWD = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(webPasswordTextBox.Text), null,DataProtectionScope.CurrentUser));
            doc.Element("Settings").SetElementValue("WebPassword", encryptedPWD);

            doc.Save("config.xml");

        }

        private void new_teams_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if(new_teams_checkBox.Checked) 
            {
                chat_checkBox.Enabled = false;
                call_checkBox.Enabled = false;
            }
            else
            {
                chat_checkBox.Enabled = true;
                call_checkBox.Enabled = true;
            }
        }
    }
}

using System;
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
            var ports = new List<string>();
            ports.Add("---");
            ports.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            
            cmbSerialPorts.DataSource = ports;

            XDocument doc = XDocument.Load("config.xml");

            cmbSerialPorts.SelectedIndex = cmbSerialPorts.FindStringExact(doc.Element("Settings").Element("ComPort").FirstAttribute.Value.ToString());
            textBox1.Text = doc.Element("Settings").Element("URL").FirstAttribute.Value.ToString();
            minimize_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Minimize").FirstAttribute.Value);
            notification_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onNotification").Value);
            chat_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onChat").Value);
            call_checkBox.Checked = Convert.ToBoolean(doc.Element("Settings").Element("Flash").Attribute("onCall").Value);
        }

        private void OkButtonClick(object sender, EventArgs e)
        {
            XDocument doc = XDocument.Load("config.xml");
            doc.Element("Settings").Element("Minimize").ReplaceAttributes(new XAttribute("afterStart",minimize_checkBox.Checked.ToString()));
            doc.Element("Settings").Element("Flash").ReplaceAttributes(
                new XAttribute("onNotification",notification_checkBox.Checked.ToString()),
                new XAttribute("onChat", chat_checkBox.Checked.ToString()),
                new XAttribute("onCall", call_checkBox.Checked.ToString()));
            doc.Element("Settings").Element("ComPort").ReplaceAttributes( new XAttribute("Name", cmbSerialPorts.SelectedItem.ToString()));
            doc.Element("Settings").Element("URL").ReplaceAttributes(new XAttribute("Adress", textBox1.Text));
            doc.Save("config.xml");

        }
    }
}

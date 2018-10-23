using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace HHsystem.Controllers
{
    class SettingController
    {
        private string location = "..\\..\\Settings.xml";
        string backLocation;
        string RefreshRate;
        string CalendarDays;
        string Resolution;

        public SettingController()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(location);
            XmlNode node = doc.DocumentElement.SelectSingleNode("/Settings/BackupLocation");
            backLocation = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/Settings/RefreshRate");
            RefreshRate = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/Settings/CalendarDays");
            CalendarDays = node.InnerText;
            node = doc.DocumentElement.SelectSingleNode("/Settings/Resolution");
            Resolution = node.InnerText;
        }

        public void setSettings(string backLocation,
        string RefreshRate,
        string CalendarDays,
        string Resolution)
        {
            XmlTextWriter xmlWriter = new XmlTextWriter(location, null);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Settings");

            xmlWriter.WriteStartElement("BackupLocation");
            xmlWriter.WriteString(backLocation);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("RefreshRate");
            xmlWriter.WriteString(RefreshRate);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("CalendarDays");
            xmlWriter.WriteString(CalendarDays);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("Resolution");
            xmlWriter.WriteString(Resolution);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public string getBackLocation()
        {
            return backLocation;
        }

        public string getRefreshRate()
        {
            return RefreshRate;
        }

        public string getCalendarDays()
        {
            return CalendarDays;
        }

        public string getResolution()
        {
            return Resolution;
        }


    }
}

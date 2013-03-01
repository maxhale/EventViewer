using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace EventViewerParser
{
    class EventViewerParserID
    {
        private string fileLocation = @"C:\Logs\EventView.txt";
        private DateTime day = DateTime.Today;
        private string appName = "";

        public EventViewerParserID(int _daysBack, string app)
        {
            DateTime day = DateTime.Today.Subtract(new TimeSpan(_daysBack, 0, 0, 0));
            appName = app;
        }

        public void getLogData()
        {
            try
            {
                EventLog myLog = new EventLog();
                myLog.Log = "Application";

                if (!File.Exists(fileLocation))
                {
                    File.Create(fileLocation);
                }
                String xmlReturn = "";
                StreamWriter sw = new StreamWriter(xmlReturn);
                //StreamWriter sw = new StreamWriter(fileLocation, false);
                foreach (EventLogEntry entry in myLog.Entries)
                {
                    Match containsAppName = Regex.Match(entry.Message, appName);
                    if (entry.EntryType.ToString() == "Error" && entry.TimeGenerated.Date == DateTime.Today) //entry.EntryType.ToString() == "Warning" || 
                    {
                        if (appName != "" && containsAppName.Success)
                        {
                            Console.WriteLine("Found entry.");
                            buildXML(entry, sw);
                        }
                        else if (appName == "")
                        {
                            buildXML(entry, sw);
                        }
                    }
                }
                ConnectionHandler connectionHandler = new ConnectionHandler();
                connectionHandler.UploadErrorLog(xmlReturn);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void buildXML(EventLogEntry entry, StreamWriter file)
        {
            XMLBuilder xml = new XMLBuilder();
            xml.Category = entry.Category; //??
            xml.EntryType = entry.EntryType.ToString(); //Warning or Error
            xml.Message = entry.Message; //Detail of error
            xml.Source = entry.Source; //Should be application name
            xml.MachineName = entry.MachineName;
            xml.UserName = entry.UserName;
            xml.TimeGenerated = entry.TimeGenerated.ToString();
            XmlSerializer x = new XmlSerializer(xml.GetType());
            x.Serialize(file, xml);
        }
    }
}
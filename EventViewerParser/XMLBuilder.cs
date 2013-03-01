
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventViewerParser
{
    public class XMLBuilder
    {
        public string EntryType { get; set; }
        public string TimeGenerated { get; set; }
        public string Source { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string MachineName { get; set; }
        public string UserName { get; set; }

        public XMLBuilder()
        {
            EntryType = "";
            TimeGenerated = "";
            Source = "";
            Message = "";
            Category = "";
            MachineName = "";
            UserName = "";
        }
    }
}
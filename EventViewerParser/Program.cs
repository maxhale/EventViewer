using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;

namespace EventViewerParser
{
    class Program
    {
        private static int _daysBack = 0;
        private static string _specificApp = "";

        static int Main(string[] args)
        {
            if (!ProcessArgs(args))
            {
                Console.WriteLine(Usage);
                return -1;
            }
            else
            {
                EventViewerParserID parse = new EventViewerParserID(_daysBack, _specificApp);
                parse.getLogData();
                
            }
            return 0;
        }

        private static bool ProcessArgs(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine(Usage);
                return false;
            }
            foreach (string arg in args)
            {
                if (arg.StartsWith("/d:"))
                {
                    string numStr = arg.Replace("/d:", "");
                    if (!int.TryParse(numStr, out _daysBack))
                        return false;
                    if (_daysBack < 0)
                        return false;
                }
                else if (arg.StartsWith("/app:"))
                {
                    _specificApp = arg.Replace("/app:", "");
                    if (_specificApp.Length == 0)
                        return false;
                }
                else
                {
                    Console.WriteLine(Usage);
                    return false;
                }
            }
            return true;
        }

        static string Usage
        {
            get { return "USAGE: EventViewer.exe [/d:DAYS_BACK] [/app:Application]\n/d:0 would be today"; }
        }
    }
}
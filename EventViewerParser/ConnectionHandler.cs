using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventViewerParser
{
    class ConnectionHandler
    {
        public void UploadErrorLog(String xml)
        {

            ServiceRef.ServiceClient client = new ServiceRef.ServiceClient();
            String returnV = client.UploadErrorLog(xml);

            Console.WriteLine(returnV);

            
        }
    }
}

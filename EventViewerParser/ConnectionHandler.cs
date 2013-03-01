using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventViewerParser
{
    class ConnectionHandler
    {
        public void testSubmit()
        {

            ServiceRef.ServiceClient client = new ServiceRef.ServiceClient();
            String returnV = client.UploadErrorLog(1);

            Console.WriteLine(returnV);

            
        }
    }
}

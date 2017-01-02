using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace KeepGovmeetingWebsiteAlive
{
    class Program
    {
        static void Main(string[] args)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadString("http://govmeeting.org/");
            }
        }
    }
}

using System;
using System.Net.Http;

namespace KeepWebsiteAliveApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (HttpClient client = new HttpClient())
            {
                client.GetStringAsync("https://govmeeting.org/");
            }
        }
    }
}

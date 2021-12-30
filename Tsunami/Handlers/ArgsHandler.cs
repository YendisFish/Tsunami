using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tsunami.Types;

namespace Tsunami.Handlers
{
    public class ArgsHandler
    {
        public static void Handle(string[] arguments)
        {
            try
            {
                if(arguments.Count() == 4)
                {
                    if (Enum.Parse<Args>(arguments[0]) == Args.http)
                    {
                        Flooder.HttpFlooder(arguments[1], int.Parse(arguments[2]), int.Parse(arguments[3]));
                    }
                }
                
                if(arguments.Count() == 3)
                {
                    if (Enum.Parse<Args>(arguments[0]) == Args.http)
                    {
                        Flooder.HttpFlooder(arguments[1], int.Parse(arguments[2]));
                    }
                } 

                if(arguments.Count() > 3)
                {
                    throw new Exception();
                }

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

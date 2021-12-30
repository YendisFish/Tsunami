using Tsunami.Handlers;

namespace Tsunami.Main
{
    public class TsunamiEntrypoint
    {
        public static void Main(string[] args)
        {
            ArgsHandler.Handle(args);
        }
    }
}
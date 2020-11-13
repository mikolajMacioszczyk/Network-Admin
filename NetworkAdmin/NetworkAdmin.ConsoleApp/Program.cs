using NetworkAdmin.ConsoleApp.Helpers;
using NetworkAdmin.ConsoleApp.Managers;

namespace NetworkAdmin.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ConsoleAppManager(new KeyboardInteraction());
            manager.Run();
        }
    }
}
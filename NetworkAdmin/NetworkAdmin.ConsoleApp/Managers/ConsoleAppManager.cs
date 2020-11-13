using System;
using NetworkAdmin.ConsoleApp.Helpers;

namespace NetworkAdmin.ConsoleApp.Managers
{
    public class ConsoleAppManager : IActionManager
    {
        private readonly KeyboardInteraction _keyboardInteraction;

        public ConsoleAppManager(KeyboardInteraction keyboardInteraction)
        {
            _keyboardInteraction = keyboardInteraction;
        }

        private void ShowProtocolVersionMenu()
        {
            Console.WriteLine("============= Protocol Version Menu =============");
            Console.WriteLine("1. Ipv4");
            Console.WriteLine("2. Ipv6");
            Console.WriteLine("0. Zakończ");
        }
        public int Run()
        {
            int state = Int32.MinValue; 
            while (state != 0)
            {
                ShowProtocolVersionMenu();
                state = _keyboardInteraction.ReadNumber();
                switch (state)
                {
                    case 1:
                        state = ServeRedirectionToActionManager(new Ipv4ActionsManager(_keyboardInteraction));
                        break;
                    case 2:
                        state = ServeRedirectionToActionManager(new Ipv6ActionManager());
                        break;
                    case 0:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine(state + " is not in options.");
                        break;
                }
            }
            return state;
        }

        private int ServeRedirectionToActionManager(IActionManager manager)
        {
            return manager.Run();
        }
    }
}
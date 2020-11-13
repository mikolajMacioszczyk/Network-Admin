using System;
using NetworkAdmin.ConsoleApp.Actions;
using NetworkAdmin.ConsoleApp.Helpers;

namespace NetworkAdmin.ConsoleApp.Managers
{
    public class Ipv4ActionsManager: IActionManager
    {
        private readonly KeyboardInteraction _keyboardInteraction;

        public Ipv4ActionsManager(KeyboardInteraction keyboardInteraction)
        {
            _keyboardInteraction = keyboardInteraction;
        }

        private void ShowIpv4Menu()
        {
            Console.WriteLine("============= Ipv4 Menu =============");
            Console.WriteLine("1. Wczytaj sieć");
            Console.WriteLine("2. Stwórz sieć");
            Console.WriteLine("3. Sprawdź adres");
            Console.WriteLine("-1. Wróć");
            Console.WriteLine("0. Zakończ program");
        }
        
        public int Run()
        {
            int state = Int32.MinValue;
            while (state != 0 && state != -1)
            {
                ShowIpv4Menu();
                state = _keyboardInteraction.ReadNumber();
                switch (state)
                {
                    case 1:
                        throw new NotImplementedException();
                    case 2:
                        throw new NotImplementedException();
                    case 3:
                        state = ServeRedirectionToActionManager(new CheckAddressActionManager(_keyboardInteraction, new CheckIpv4AddressActions(_keyboardInteraction)));
                        break;
                    case 9:
                        break;
                    case 0:
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
            var result = manager.Run();
            if (result == 0 || result == 9)
            {
                return result;
            }
            return 100;
        }
    }
}
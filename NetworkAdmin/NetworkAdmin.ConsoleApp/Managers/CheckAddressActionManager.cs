using System;
using NetworkAdmin.ConsoleApp.Actions;
using NetworkAdmin.ConsoleApp.Helpers;

namespace NetworkAdmin.ConsoleApp.Managers
{
    public class CheckAddressActionManager : IActionManager
    {
        private readonly IKeyboardInteraction _keyboardInteraction;
        private readonly CheckIpv4AddressActions _actions;
        
        public CheckAddressActionManager(IKeyboardInteraction keyboardInteraction, CheckIpv4AddressActions actions)
        {
            _keyboardInteraction = keyboardInteraction;
            _actions = actions;
        }

        private void ShowMenu()
        {
            Console.WriteLine("============= Check Address Menu =============");
            Console.WriteLine("1. Is Host Address Valid");
            Console.WriteLine("2. Get Address Type");
            Console.WriteLine("3. Get Network Address");
            Console.WriteLine("4. Get BroadCast Address of Network");
            Console.WriteLine("5. Get First Address of Network");
            Console.WriteLine("6. Get Last Address of Network");
            Console.WriteLine("7. Get Subnet Mask of Network");
            Console.WriteLine("8. Get Class of Address");
            Console.WriteLine("9. Get Subnet Network Bit Count");
            Console.WriteLine("10. Get Host Bit Count");
            Console.WriteLine("11. Get Possible Subnets Count");
            Console.WriteLine("12. Get Possible Host Count");
            Console.WriteLine("==========================");
            Console.WriteLine("13. Get Full Network Data");
            Console.WriteLine("14. Binary Address From Decimal Address");
            Console.WriteLine("15. Decimal Address From Binary Address");
            Console.WriteLine("==========================");
            Console.WriteLine("-1. Powrót");
            Console.WriteLine("0. Zakończ");
        }
        public int Run()
        {
            int state = Int32.MinValue;
            while (state != 0 && state != -1)
            {
                ShowMenu();
                state = _keyboardInteraction.ReadNumber();
                switch (state)
                {
                    case 1:
                        Console.WriteLine(_actions.ServeIsHostValid());
                        break;
                    case 2:
                        Console.WriteLine(_actions.ServeGetAddressType());
                        break;
                    case 3:
                        Console.WriteLine(_actions.GetNetworkAddress());
                        break;
                    case 4:
                        Console.WriteLine(_actions.GetBroadcastAddress());
                        break;
                    case 5:
                        Console.WriteLine(_actions.GetFirstHostAddress());
                        break;
                    case 6:
                        Console.WriteLine(_actions.GetLastHostAddress());
                        break;
                    case 7:
                        new SubnetMaskOfNetworkActionManager(_keyboardInteraction).Run();
                        break;
                    case 8:
                        Console.WriteLine(_actions.GetClassAddress());
                        break;
                    case 9:
                        Console.WriteLine(_actions.SubnetNetworkBitCount());
                        break;
                    case 10:
                        Console.WriteLine(_actions.GetHostBitCount());
                        break;
                    case 11:
                        Console.WriteLine(_actions.GetPossibleSubnetsCount());
                        break;
                    case 12:
                        Console.WriteLine(_actions.GetPossibleHostCount());
                        break;
                    case 13:
                        Console.WriteLine(_actions.GetFullNetworkData());
                        break;
                    case 14:
                        Console.WriteLine(_actions.BinaryFromDecimal());
                        break;
                    case 15:
                        Console.WriteLine(_actions.DecimalFromBinary());
                        break;
                    case -1:
                    case 0: 
                        break;
                    default:
                        Console.WriteLine(state + " is not in options.");
                        break;
                }
            }
            return state;
        }
    }
}
using System;

namespace NetworkAdmin.ConsoleApp.Helpers
{
    public class KeyboardInteraction: IKeyboardInteraction
    {
        public int ReadNumber()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return ReadNumber();
            }
            try
            {
                return int.Parse(input);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Please, type number.");
                return ReadNumber();
            }
        }

        public string ReadString()
        {
            var input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                return ReadString();
            }
            return input;
        }
    }
}
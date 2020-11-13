using NetworkAdmin.ConsoleApp.Helpers;

namespace NetworkAdmin.Tests.ConsoleAppTests
{
    public class MockKeyboardInteraction: IKeyboardInteraction
    {
        public virtual int ReadNumber()
        {
            return 0;
        }

        public virtual string ReadString()
        {
            return "";
        }
    }
}
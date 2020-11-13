using System;

namespace NetworkAdmin.Exceptions
{
    public class IncorrectIpv4AddressException : Exception
    {
        private string Address;

        public IncorrectIpv4AddressException(string address, string message) : base(message)
        {
            Address = address;
        }
    }
}
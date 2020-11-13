﻿using NetworkAdmin.IpAddress.Range;

namespace NetworkAdmin.IpAddress.Utils
{
    public interface IPAddressUtils<T> where T : IPAddress
    {
        bool IsLegalHostAddress(T address, ushort networkPortion);

        bool IsValidNetworkPortion(T address, int networkPortion);

        IPRange<T> GetAddressRange(T address);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzuliaDesigns.WakeOnLan.Helpers
{
    public class IPAddressHelpers
    {
        public static long IPStringToLong(string addr)
        {
            IPAddress address = IPAddress.Parse(addr);
            byte[] bytes = address.GetAddressBytes();
            Array.Reverse(bytes);
            uint intAddress = BitConverter.ToUInt32(bytes, 0);
            return intAddress;
        }

        public static IPAddress LongToIPAddress(long address)
        {
            return IPAddress.Parse(address.ToString());
        }
    }
}

using AzuliaDesigns.WakeOnLan.Extensions;
using System;
using System.Net;
using System.Net.Sockets;

namespace AzuliaDesigns.WakeOnLan.Logic
{
    public static class WakeOnLanLogic
    {
        public static void WakeDevice(string ipAddress, string subnetMask, string macAddress)
        {
            UdpClient client = new UdpClient();
            byte[] payload = GetWOLPayload(macAddress);
            IPAddress address = IPAddress.Parse(ipAddress);
            IPAddress mask = IPAddress.Parse(subnetMask);
            IPAddress broadcastAddress = address.GetBroadcastAddress(mask);

            client.Send(payload, payload.Length, broadcastAddress.ToString(), 3);
        }

        private static byte[] GetWOLPayload(string macAddress)
        {
            Byte[] payload = new byte[102];

            for (int i = 0; i <= 5; i++)
            {
                payload[i] = 0xff;
            }

            string[] macDigits = null;
            if (macAddress.Contains("-"))
            {
                macDigits = macAddress.Split('-');
            }
            else
            {
                macDigits = macAddress.Split(':');
            }

            if (macDigits.Length != 6)
            {
                throw new ArgumentException("Incorrect MAC address supplied!");
            }

            int start = 6;
            for (int i = 0; i < 16; i++)
            {
                for (int x = 0; x < 6; x++)
                {
                    payload[start + i * 6 + x] = (byte)Convert.ToInt32(macDigits[x], 16);
                }
            }

            return payload;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AzuliaDesigns.WakeOnLan.Objects
{
    public class Config
    {
        public List<WakableDevice> Devices { get; set; }

        public Config()
        {
            Devices = new List<WakableDevice>();
        }
    }

    public class WakableDevice
    {
        public string IPAddress { get; set; }

        public string Subnet { get; set; }

        public string MacAddress { get; set; }

        public string Name { get; set; }

    }
}

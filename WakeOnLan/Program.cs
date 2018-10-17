using System;
using System.IO;
using Newtonsoft.Json;
using AzuliaDesigns.WakeOnLan.Objects;
using AzuliaDesigns.WakeOnLan.Logic;

namespace AzuliaDesigns.WakeOnLan
{
    class Program
    {
        static void Main(string[] args)
        {
            Config config = ReadConfiguration();
            bool running = true;
            string input = "";

            while (running)
            {
                DisplayMenu(config);
                input = Console.ReadLine();

                if (input == "q")
                {
                    running = false;
                }
                else
                {
                    if (int.TryParse(input, out int selection))
                    {
                        if (selection <= config.Devices.Count)
                        {
                            var device = config.Devices[selection - 1];
                            Console.Clear();
                            Console.WriteLine("----------- Wake On Lan -----------");
                            Console.WriteLine("Waking device '{0}'", device.Name);
                            Console.WriteLine("Please wait...");

                            WakeOnLanLogic.WakeDevice(device.IPAddress, device.Subnet, device.MacAddress);

                            Console.WriteLine("WoL Packets Transmitted. Device should be booting.");
                            Console.WriteLine("Press any key to continue.");
                            Console.ReadKey();
                        }
                    }
                }
            }
        }

        private static void DisplayMenu(Config config)
        {
            Console.Clear();
            Console.WriteLine("----------- Wake On Lan -----------");
            Console.WriteLine("Devices:");
            Console.WriteLine("");
            Console.WriteLine("       IP Address      Subnet          Mac Address        Name");
            Console.WriteLine("");

            int count = 1;
            foreach (WakableDevice device in config.Devices)
            {
                Console.WriteLine("    {0}. {1} {2} {3}  {4}", count, device.IPAddress.PadRight(15), device.Subnet.PadRight(15), device.MacAddress, device.Name);
                count++;
            }
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Select a Device to Wake or 'q' to Quit: ");
        }

        private static Config ReadConfiguration()
        {
            string json = File.ReadAllText("config.json");
            return JsonConvert.DeserializeObject<Config>(json);
        }

        private static void WriteConfiguration(Config config)
        {
            string json = JsonConvert.SerializeObject(config);
            File.WriteAllText("config.json", json);
        }
    }
}

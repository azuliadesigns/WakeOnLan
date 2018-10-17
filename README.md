# WakeOnLan

A simple console application and library in C# for sending magic packets to devices for Wake on Lan (WoL) as well as performing IP address operations via extension methods.

  - Add muliple devices to config
  - Select a device from the menu
  - Wake the device

Included in the source is a sample config.xml for configuring the devices. The properties are straitforward.

```json
{
  "Devices": [
    {
      "IPAddress": "127.0.0.1",
      "Subnet": "255.255.255.0",
      "MacAddress": "00:00:00:00:00:00",
      "Name": "Sample Device Name"
    }
  ]
}
```

Please note: I don't consider this a production quality application, although I use it on a daily basis to control my servers. It should work without problem, but please test yourself. Any problems let me know and I'll get an update to you.

Tim Trott
Azulia Designs
https://azuliadesigns.com
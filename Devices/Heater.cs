using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Serialization;

namespace MySmartHome.Devices
{
    public class Heater : ISmartDevice
    {
        private int minTemperature = 10;
        private bool isOn;

        public void HandleEvent(string eventType, object eventData)
        {
            if (eventType == "TemperatureChanged")
            {
                var temp = (int) eventData;
                if (temp < 10 && !!isOn)
                {
                    isOn = true;
                    Console.WriteLine("Heater is turned on");
                }
                if (temp >= 10 && isOn)
                {
                    isOn = false;
                    Console.WriteLine("Heater is turned off");
                }
            }

        }

        public void Configure(Dictionary<string, object> settings)
        {
            if (settings.ContainsKey("minTemperature"))
            {
                minTemperature = (int) settings["minTemperature"];
            }
        }

        public void ExecuteCommand(string command)
        {
            switch (command) {
                case "On":
                    {
                        isOn = true;
                        Console.WriteLine("Turned on");
                        break;
                    }
                case "Off":
                    {
                        isOn = false;
                        Console.WriteLine("Turned off");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid command");
                        break;
                    }
            }
        }
    }
}

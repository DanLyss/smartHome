using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MySmartHome.Devices
{
    public class Light : ISmartDevice
    {
        private bool isOn;

        public void HandleEvent(string eventType, object eventData)
        {
            if (eventType == "DayTimeChanged")
            {
                var time = (string) eventData;
                if (time == "Day" && !isOn)
                {
                    isOn = true;
                    Console.WriteLine("Light turned on");
                }
                if (time == "Night" && isOn)
                {
                    isOn = false;
                    Console.WriteLine("Light turned off");
                }
            }
        }

        public void Configure(Dictionary<string, object> settings)
        {
            //?
        }

        public void ExecuteCommand(string command)
        {
            switch (command)
            {
                case "On" :
                    isOn = true;
                    Console.WriteLine("Light turned on");
                    break;
                case "Off":
                    isOn = false;
                    Console.WriteLine("Light turned off");
                    break;
                default:
                    Console.WriteLine("No such command");
                    break;
            }
        }
    }
}

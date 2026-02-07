using System;
using System.Collections.Generic;
using MySmartHome.Devices;

namespace SmartHomeSystem
{
    public class SmartHomeController
    {
        public event Action<string> OnDayTimeChanged;
        public event Action<int> OnTemperatureChanged;
        public event Action OnMotionDetected;

        private static readonly List<ISmartDevice> devices = new List<ISmartDevice>();
        private readonly EventLogger logger = new EventLogger();

        public void RegisterDevice(ISmartDevice device)
        {
            devices.Add(device);
        }

        public void ChangeDayTime(string timeOfDay)
        {
            Console.WriteLine($"Event: Daytime changed to {timeOfDay}.");
            logger.Log($"Daytime changed to {timeOfDay}.");
            OnDayTimeChanged?.Invoke(timeOfDay);
        }

        public void ChangeTemperature(int temperature)
        {
            Console.WriteLine($"Event: Temperature changed to {temperature}");
            logger.Log($"Temperature changed to {temperature}");
            OnTemperatureChanged?.Invoke(temperature);
        }

        public void DetectMotion()
        {
            Console.WriteLine($"Event: Motion detected");
            logger.Log("Motion detected");
            OnMotionDetected.Invoke();
        }

        public void TriggerDevice(string deviceName, string command)
        {
            foreach (var device in devices)
            {
                if ((deviceName == "AirConditioner" && (device is AirConditioner))
                || (deviceName == "Heater" && device is Heater) 
                || (deviceName == "Light" && device is Light))
                {
                    logger.Log($"Device {device.GetType()} is triggered");
                    device.ExecuteCommand(command);
                }
            }
        }

        public void ShowLog()
        {
            logger.ShowLog();
        }
    }
}

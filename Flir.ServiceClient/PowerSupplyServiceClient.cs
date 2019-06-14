using System;
using System.Collections.Generic;
using System.Linq;
using Flir.Entities;

namespace Flir.ServiceClient
{
    public class PowerSupplyServiceClient : IPowerSupplyServiceClient
    {
        private PowerSupplyDevice _connectedPowerSupplyDevice;
        private List<PowerSupplyDevice> _lstPowerSupply;

        public PowerSupplyServiceClient()
        {
            _lstPowerSupply = new List<PowerSupplyDevice>();
            _connectedPowerSupplyDevice = new PowerSupplyDevice();
        }

        public List<PowerSupplyDevice> GetPowerSupplyDevices()
        {
            //SDK get list of power supplies
            _lstPowerSupply = new List<PowerSupplyDevice>
            {
                new PowerSupplyDevice {ComPort = "COM1", Voltage = 5.5, Current = 9.98},
                new PowerSupplyDevice {ComPort = "COM2", Voltage = 6.5, Current = 4.68},
                new PowerSupplyDevice {ComPort = "COM3", Voltage = 15.5, Current = 9.58}
            };
            return _lstPowerSupply;
        }

        public PowerSupplyDevice Connect(string comPort)
        {
            try
            {
                _lstPowerSupply = GetPowerSupplyDevices();
                _connectedPowerSupplyDevice = _lstPowerSupply.FirstOrDefault(x => x.ComPort == comPort);
                //SDK physical connection to power supply
            }
            catch (Exception ex)
            {
                _connectedPowerSupplyDevice = null;
            }

            return _connectedPowerSupplyDevice;
        }


        public PowerSupplyDevice Disconnect()
        {
            try
            {
                //SDK physical disconnection to power supply
                _connectedPowerSupplyDevice = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return _connectedPowerSupplyDevice;
        }

        public double GetCurrent()
        {
            return _connectedPowerSupplyDevice.Current;
        }


        public double GetVoltage()
        {
            return _connectedPowerSupplyDevice.Voltage;
        }
    }
}
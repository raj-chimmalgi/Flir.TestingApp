using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Entities;

namespace Flir.ServiceClient
{
    public class PowerSupplyServiceClient : IPowerSupplyServiceClient
    {
        private List<PowerSupplyDevice> lstPowerSupply;
        private PowerSupplyDevice ConnectedPowerSupplyDevice;
        private double Current;
        private double Voltage;

        public PowerSupplyServiceClient()
        {
            lstPowerSupply = new List<PowerSupplyDevice>();
            ConnectedPowerSupplyDevice = new PowerSupplyDevice();

        }
        public PowerSupplyDevice Connect(string comPort)
        {
            try
            {
                lstPowerSupply = GetPowerSupplyDevices();
                ConnectedPowerSupplyDevice = lstPowerSupply.Where(x => x.ComPort == comPort).FirstOrDefault();
                //SDK physical connection to power supply
            }
            catch (Exception ex)
            {
                ConnectedPowerSupplyDevice = null;
            }

            return ConnectedPowerSupplyDevice;
        }

        public PowerSupplyDevice Disconnect()
        {

            try
            {
                //SDK physical disconnection to power supply
                ConnectedPowerSupplyDevice = null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return ConnectedPowerSupplyDevice;
        }

        public List<PowerSupplyDevice> GetPowerSupplyDevices()
        {
            //SDK get list of power supplies
            lstPowerSupply = new List<PowerSupplyDevice>()
            {
                new PowerSupplyDevice() {ComPort = "COM1", Voltage = 5.5, Current = 9.98},
                new PowerSupplyDevice() {ComPort = "COM2", Voltage = 6.5, Current = 4.68},
                new PowerSupplyDevice() {ComPort = "COM3", Voltage = 15.5, Current = 9.58}
            };
            return lstPowerSupply;
        }

        public double GetCurrent()
        {
            return ConnectedPowerSupplyDevice.Current;
        }



        public double GetVoltage()
        {
            return ConnectedPowerSupplyDevice.Voltage;
        }
    }
}

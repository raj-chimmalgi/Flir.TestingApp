using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Entities;

namespace Flir.ServiceClient
{
    class NewPowerSupplyServiceClient : INewPowerSupplyServiceClient
    {
        public PowerSupplyDevice Connect(string comPort)
        {
            throw new NotImplementedException();
        }

        public PowerSupplyDevice Disconnect()
        {
            throw new NotImplementedException();
        }

        public double GetCurrent()
        {
            throw new NotImplementedException();
        }

        public double GetPowerConsumption()
        {
            throw new NotImplementedException();
        }

        public List<PowerSupplyDevice> GetPowerSupplyDevices()
        {
            throw new NotImplementedException();
        }

        public double GetVoltage()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Entities;

namespace Flir.ServiceClient
{
    public interface IPowerSupplyServiceClient
    {
        double GetCurrent();
        double GetVoltage();
        List<PowerSupplyDevice> GetPowerSupplyDevices();
        PowerSupplyDevice Connect(string comPort);
        PowerSupplyDevice Disconnect();
    }
}

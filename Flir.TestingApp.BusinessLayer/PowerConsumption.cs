using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Entities;

namespace Flir.TestingApp.BusinessLayer
{
    public class PowerConsumption : IPowerConsumption
    {
        public bool IsPowerComsumptionWithinRange(double minWatts, double maxWatts, Camera camera)
        {
            
            if (camera.PowerConsumption >= minWatts && camera.PowerConsumption <= maxWatts) return true;

            return false;

        }

        public double PowerConsumptionInWatts(PowerSupplyDevice powerSupplyDevice)
        {
            return powerSupplyDevice.Current * powerSupplyDevice.Voltage;
        }

        
    }
}

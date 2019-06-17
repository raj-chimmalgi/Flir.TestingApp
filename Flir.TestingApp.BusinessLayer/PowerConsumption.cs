using Flir.Entities;

namespace Flir.BusinessLayer
{
    public class PowerConsumption : IPowerConsumption
    {
        public bool IsPowerConsumptionWithinRange(double minWatts, double maxWatts, Camera camera)
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
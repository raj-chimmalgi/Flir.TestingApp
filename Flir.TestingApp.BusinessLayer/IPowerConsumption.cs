using Flir.Entities;

namespace Flir.BusinessLayer
{
    public interface IPowerConsumption
    {
        double PowerConsumptionInWatts(PowerSupplyDevice powerSupplyDevice);

        bool IsPowerConsumptionWithinRange(double minWatts, double maxWatts, Camera camera);
    }
}
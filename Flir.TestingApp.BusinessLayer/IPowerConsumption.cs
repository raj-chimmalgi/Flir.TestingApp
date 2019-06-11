using Flir.Entities;

namespace Flir.BusinessLayer
{
    public interface IPowerConsumption
    {
        double PowerConsumptionInWatts(PowerSupplyDevice powerSupplyDevice);

        bool IsPowerComsumptionWithinRange(double minWatts, double maxWatts, Camera camera);
    }
}
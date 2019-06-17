using Flir.Entities;

namespace Flir.BusinessLayer
{
    public class PowerConsumption : IPowerConsumption
    {
        private readonly ILogger _logger;

        public PowerConsumption(ILogger logger)
        {
            _logger = logger;
        }

        public bool IsPowerConsumptionWithinRange(double minWatts, double maxWatts, Camera camera)
        {
            if (camera.PowerConsumption >= minWatts && camera.PowerConsumption <= maxWatts)
            {
                _logger.LogInfo("Camera Power Consumption Test Passed");
                return true;
            }

            _logger.LogInfo("Camera Power Consumption Test Failed");
            return false;
        }

        public double PowerConsumptionInWatts(PowerSupplyDevice powerSupplyDevice)
        {
            var powerConsumption = powerSupplyDevice.Current * powerSupplyDevice.Voltage;

            _logger.LogInfo($"Power consumption in watts: {powerConsumption}");

            return powerConsumption;
        }
    }
}
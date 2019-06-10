using Flir.Entities;
using Flir.TestingApp.BusinessLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flir.UnitTest
{
    [TestClass]
    public class PowerConsumptionTests
    {
        private readonly PowerConsumption powerConsumption;

        public PowerConsumptionTests()
        {
            powerConsumption = new PowerConsumption();
        }

        [TestMethod]
        public void Should_Calculate_PowerConsumptionInWatts()
        {
            var powerSupplyDevice = new PowerSupplyDevice();
            powerSupplyDevice.Voltage = 2.5;
            powerSupplyDevice.Current = 4;

            var result = powerConsumption.PowerConsumptionInWatts(powerSupplyDevice);

            Assert.AreEqual(10, result);
        }

        [DataTestMethod]
        [DataRow(5, 10, 5)]
        [DataRow(5, 10, 8)]
        [DataRow(5, 10, 7)]
        public void Is_Camera_Power_Consumption_Within_Range(double minWatts, double maxWatts, double powerConsupmtion)
        {
            var camera = new Camera
            {
                PowerConsumption = powerConsupmtion
            };

            var result = powerConsumption.IsPowerComsumptionWithinRange(minWatts, maxWatts, camera);

            Assert.IsTrue(result);
        }

        [DataTestMethod]
        [DataRow(5, 10, 50)]
        [DataRow(5, 10, 1)]
        [DataRow(5, 10, 45)]
        public void Is_Camera_Power_Consumption_Not_Within_Range(double minWatts, double maxWatts,
            double powerConsupmtion)
        {
            var camera = new Camera
            {
                PowerConsumption = powerConsupmtion
            };

            var result = powerConsumption.IsPowerComsumptionWithinRange(minWatts, maxWatts, camera);

            Assert.IsFalse(result);
        }
    }
}
using System;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flir.TestingApp.BusinessLayer;
using Flir.Entities;

namespace Flir.UnitTest
{
    [TestClass]
    public class PowerConsumptionUnitTests
    {
        private PowerConsumption powerConsumption;

        public PowerConsumptionUnitTests()
        {
            powerConsumption = new PowerConsumption();
        }

        [TestMethod]
        public void Should_Calculate_PowerConsumptionInWatts()
        {
            var powerSupplyDevice = new PowerSupplyDevice();
            powerSupplyDevice.Voltage = 2.5;
            powerSupplyDevice.Current = 4;

            double result = powerConsumption.PowerConsumptionInWatts(powerSupplyDevice);

            Assert.AreEqual(10, result);


        }

        [TestMethod]
        public void Is_Camera_Power_Consumption_Within_Range()
        {
            double minWatts = 5;
            double maxWatts = 10;
            
            var camera = new Camera();
            camera.PowerConsumption = 5;

            bool result = powerConsumption.IsPowerComsumptionWithinRange(minWatts, maxWatts, camera);

            Assert.IsTrue(result);

        }

        [TestMethod]
        public void Is_Camera_Power_Consumption_Not_Within_Range()
        {
            double minWatts = 5;
            double maxWatts = 10;
            
            var camera = new Camera();
            camera.PowerConsumption = 4;

            bool result = powerConsumption.IsPowerComsumptionWithinRange(minWatts, maxWatts, camera);

            Assert.IsFalse(result);

        }
    }
}

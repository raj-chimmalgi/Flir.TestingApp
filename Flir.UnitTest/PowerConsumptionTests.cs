﻿using Flir.BusinessLayer;
using Flir.Entities;
using NUnit.Framework;

namespace Flir.UnitTests
{
    [TestFixture]
    public class PowerConsumptionTests
    {
        private IPowerConsumption _powerConsumption;

        [SetUp]
        public void SetUp()
        {
            _powerConsumption = new PowerConsumption();
        }

        [Test]
        [TestCase(5, 10, 5, true)]
        [TestCase(5, 10, 8, true)]
        [TestCase(5, 10, 14, false)]
        public void IsPowerComsumptionWithinRange_WhenCalled_ReturnIsWithinRange(double minWatts, double maxWatts,
            double powerConsupmtion, bool expectedResult)
        {
            var camera = new Camera
            {
                PowerConsumption = powerConsupmtion
            };

            var result = _powerConsumption.IsPowerComsumptionWithinRange(minWatts, maxWatts, camera);

            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        [TestCase(2.5, 5.6, 14.0)]
        [TestCase(5.5, 6.4, 35.2)]
        [TestCase(3.3, 3.1, 10.23)]
        public void PowerConsumptionInWatts_WhenCalled_ReturnPowerConsumption(double voltage, double current,
            double expectedResult)
        {
            var powerSupplyDevice = new PowerSupplyDevice
            {
                Voltage = voltage,
                Current = current
            };

            var result = _powerConsumption.PowerConsumptionInWatts(powerSupplyDevice);

            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
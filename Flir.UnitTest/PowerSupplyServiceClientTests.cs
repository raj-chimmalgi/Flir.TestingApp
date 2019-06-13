using Flir.ServiceClient;
using NUnit.Framework;
using System.Linq;
using Flir.Entities;
using System.Collections.Generic;

namespace Flir.UnitTests
{
    /// <summary>
    ///     Unit tests for PowerSupplyServiceClient
    /// </summary>
    [TestFixture]
    public class PowerSupplyServiceClientTests
    {
        [SetUp]
        public void SetUp()
        {
            _powerSupplyServiceClient = new PowerSupplyServiceClient();
        }

        private IPowerSupplyServiceClient _powerSupplyServiceClient;

        [Test]
        public void Connect_CannotConnect_ReturnNullPowerSupplyDevice()
        {
            const string comPort = "COM5";

            var result = _powerSupplyServiceClient.Connect(comPort);

            Assert.IsNull(result);
        }

        [Test]
        public void Connect_WhenCalled_ReturnPowerSupplyDevice()
        {
            const string comPort = "COM1";

            var result = _powerSupplyServiceClient.Connect(comPort);

            Assert.IsNotNull(result);
        }

        [Test]
        public void Disconnect_WhenCalled_ReturnNullPowerSupplyDevice()
        {
            var result = _powerSupplyServiceClient.Disconnect();

            Assert.IsNull(result);
        }

        [Test]
        public void GetCurrent_WhenCalled_ReturnPowerSupplyDeviceUpdatedWithCurrent()
        {
            const string comPort = "COM2";

            var powerSupplyDevice = _powerSupplyServiceClient.Connect(comPort);

            var result = _powerSupplyServiceClient.GetCurrent();

            Assert.That(result, Is.EqualTo(4.68));
        }

        [Test]
        public void GetVoltage_WhenCalled_ReturnPowerSupplyDeviceUpdatedWithVoltage()
        {
            const string comPort = "COM2";

            var powerSupplyDevice = _powerSupplyServiceClient.Connect(comPort);

            var result = _powerSupplyServiceClient.GetVoltage();

            Assert.That(result, Is.EqualTo(6.5));
        }

        [Test]
        public void GetPowerSupplyDevices_WhenCalled_ReturnPowerSupplyDevices()
        {
            var result = _powerSupplyServiceClient.GetPowerSupplyDevices();

            Assert.IsInstanceOf(typeof(List<PowerSupplyDevice>), result);

            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(1));
        }
    }
}
using Flir.ServiceClient;
using NUnit.Framework;
using System.Linq;
using Flir.Entities;
using System.Collections.Generic;
using Moq;

namespace Flir.UnitTests
{
    /// <summary>
    ///     Unit tests for PowerSupplyServiceClient
    /// </summary>
    [TestFixture]
    public class PowerSupplyServiceClientTests
    {
        private IPowerSupplyServiceClient _powerSupplyServiceClient;
        private Mock<IPowerSupplyServiceClient> _powerSupplyServiceClientMock;

        [SetUp]
        public void SetUp()
        {
            _powerSupplyServiceClient = new PowerSupplyServiceClient();

            _powerSupplyServiceClientMock.Setup(p => p.GetPowerSupplyDevices()).Returns(new List<PowerSupplyDevice>
            {
                new PowerSupplyDevice {ComPort = "COM1", Voltage = 5.5, Current = 9.98},
                new PowerSupplyDevice {ComPort = "COM2", Voltage = 6.5, Current = 4.68},
                new PowerSupplyDevice {ComPort = "COM3", Voltage = 15.5, Current = 9.58}
            });
        }

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
        public void GetPowerSupplyDevices_WhenCalled_ReturnPowerSupplyDevices()
        {
            var result = _powerSupplyServiceClient.GetPowerSupplyDevices();

            Assert.IsInstanceOf(typeof(List<PowerSupplyDevice>), result);

            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void GetVoltage_WhenCalled_ReturnPowerSupplyDeviceUpdatedWithVoltage()
        {
            const string comPort = "COM2";

            var powerSupplyDevice = _powerSupplyServiceClient.Connect(comPort);

            var result = _powerSupplyServiceClient.GetVoltage();

            Assert.That(result, Is.EqualTo(6.5));
        }
    }
}
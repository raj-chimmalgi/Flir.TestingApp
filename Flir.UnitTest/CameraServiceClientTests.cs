using System.Collections.Generic;
using System.Linq;
using Flir.Entities;
using Flir.ServiceClient;
using NUnit.Framework;

namespace Flir.UnitTests
{
    [TestFixture]
    public class CameraServiceClientTests
    {
        [SetUp]
        public void SetUp()
        {
            _iCameraServiceClient = new CameraServiceClient();
        }

        private ICameraServiceClient _iCameraServiceClient;

        [Test]
        public void Connect_WhenCalled_ReturnCamera()
        {
            var result = _iCameraServiceClient.Connect(1);

            Assert.IsInstanceOf(typeof(Camera), result);
        }

        [Test]
        public void Disconnect_WhenCalled_ReturnCamera()
        {
            var result = _iCameraServiceClient.Disconnect(1);

            Assert.IsInstanceOf(typeof(Camera), result);
        }

        [Test]
        public void GetCameras_WhenCalled_ReturnListOfCameras()
        {
            var result = _iCameraServiceClient.GetCameras();

            Assert.IsInstanceOf(typeof(List<Camera>), result);
            Assert.That(result.Count(), Is.GreaterThanOrEqualTo(1));
        }

        [Test]
        public void StartStreaming_WhenCalled_ReturnTrue()
        {
            var result = _iCameraServiceClient.StartStreaming();

            Assert.IsTrue(result);
        }

        [Test]
        public void StopStreaming_WhenCalled_ReturnTrue()
        {
            var result = _iCameraServiceClient.StopStreaming();

            Assert.IsTrue(result);
        }
    }
}
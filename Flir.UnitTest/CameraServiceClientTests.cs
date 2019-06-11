using Flir.Entities;
using Flir.ServiceClient;
using NUnit.Framework;
using System.Collections.Generic;

namespace Flir.UnitTests
{
    [TestFixture]
    public class CameraServiceClientTests
    {
        private ICameraServiceClient _iCameraServiceClient;

        [SetUp]
        public void SetUp()
        {
            _iCameraServiceClient = new CameraServiceClient();
        }

        [Test]
        public void GetCameras_WhenCalled_ReturnListOfCameras()
        {
            var result = _iCameraServiceClient.GetCameras();
            Assert.IsInstanceOf(typeof(List<Camera>), result);
        }

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
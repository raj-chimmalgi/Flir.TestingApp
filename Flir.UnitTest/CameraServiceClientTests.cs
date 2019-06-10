using Flir.Entities;
using Flir.ServiceClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flir.UnitTests
{
    [TestClass]
    public class CameraServiceClientTests
    {
        private readonly ICameraServiceClient _iCameraServiceClient;

        public CameraServiceClientTests()
        {
            _iCameraServiceClient = new CameraServiceClient();
        }

        [TestMethod]
        public void Should_Return_Cameras_GetCamerasTest()
        {
            var result = _iCameraServiceClient.GetCameras();
            CollectionAssert.AllItemsAreInstancesOfType(result, typeof(Camera));
        }

        [TestMethod]
        public void Can_Camera_DisconnectTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Can_ConnectTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Can_StartStreamingTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Can_StopStreamingTest()
        {
            Assert.Fail();
        }
    }
}
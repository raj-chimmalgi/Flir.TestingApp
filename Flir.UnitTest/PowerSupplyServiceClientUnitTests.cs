using System;
using System.Text;
using System.Collections.Generic;
using Flir.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Flir.ServiceClient;


namespace Flir.UnitTest
{
    /// <summary>
    /// Summary description for PowerSupplyServiceClientUnitTests
    /// </summary>
    [TestClass]
    public class PowerSupplyServiceClientUnitTests
    {
        IPowerSupplyServiceClient powerSupplyServiceClient;

        public PowerSupplyServiceClientUnitTests()
        {
            powerSupplyServiceClient = new PowerSupplyServiceClient(); 
        }
            
        [TestMethod]
        public void Can_Connect()
        {
            
            string comPort = "COM1";
            
            PowerSupplyDevice powerSupplyDevice = powerSupplyServiceClient.Connect(comPort);

            Assert.IsNotNull(powerSupplyDevice);

        }

        [TestMethod]
        public void Cannot_Connect()
        {
            
            string comPort = "COM5";

            PowerSupplyDevice powerSupplyDevice = powerSupplyServiceClient.Connect(comPort);

            Assert.IsNull(powerSupplyDevice);

        }

        [TestMethod]
        public void Can_Disconnect()
        {
            PowerSupplyDevice result = powerSupplyServiceClient.Disconnect();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Can_GetCurrent()
        {
            string comPort = "COM2";

            PowerSupplyDevice powerSupplyDevice = powerSupplyServiceClient.Connect(comPort);
        
            double result = powerSupplyServiceClient.GetCurrent();

            Assert.AreEqual(4.68 ,result);
        }

        [TestMethod]
        public void Can_GetVoltage()
        {
            string comPort = "COM2";

            PowerSupplyDevice powerSupplyDevice = powerSupplyServiceClient.Connect(comPort);

            double result = powerSupplyServiceClient.GetVoltage();

            Assert.AreEqual(6.5, result);
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Flir.ServiceClient;
using Flir.TestingApp.BusinessLayer;

namespace Flir.CameraTestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int cameraId;
            string comPort;
            double minWatts, maxWatts;

            ICameraServiceClient cameraServiceClient = new CameraServiceClient();
            IPowerSupplyServiceClient powerSupplyServiceClient = new PowerSupplyServiceClient();
           
            foreach (var c in cameraServiceClient.GetCameras())
            {
                Console.WriteLine("ID:{0} Name:{1}", c.Id, c.Name);
            }
           
            Console.WriteLine("Select a camera by ID: ");
            cameraId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Connecting to Camera {0}.....",cameraId);
            var camera = cameraServiceClient.Connect(cameraId);
            Console.WriteLine("connected to camera {0}", camera.Name );

            foreach (var p in powerSupplyServiceClient.GetPowerSupplyDevices())
            {
                Console.WriteLine("Com Port:{0}", p.ComPort);
            }
            
            Console.WriteLine("Select a power supply by com port:");
            comPort = Console.ReadLine();
            Console.WriteLine("Connecting to power supply on {0}.....", comPort);
            var powerSupply = powerSupplyServiceClient.Connect(comPort);
            Console.WriteLine("Connected to power supply on {0}", powerSupply.ComPort);
            cameraServiceClient.StartStreaming();
            Console.WriteLine("camera started streaming......");

            Console.WriteLine("Input accecptable range in Watts seperated by comma ex. min,max:  ");
            var range = Console.ReadLine();
            var lstRange = range.Split(',');


            IPowerConsumption powerConsumption = new PowerConsumption();

            camera.PowerConsumption = powerConsumption.PowerConsumptionInWatts(powerSupply);

            bool passed = powerConsumption.IsPowerComsumptionWithinRange(Convert.ToDouble(lstRange[0]), Convert.ToDouble(lstRange[1]), camera);

            Console.WriteLine(passed ? "Test Passed!" : "Test Failed");
        }
    }
}

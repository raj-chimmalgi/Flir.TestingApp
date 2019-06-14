using System;
using Flir.BusinessLayer;
using Flir.Entities;
using Flir.ServiceClient;

namespace Flir.CameraTestConsoleApp
{
    internal class Program
    {
        static string msg;

        private static void Main(string[] args)
        {
            ICameraServiceClient cameraServiceClient = new CameraServiceClient();
            IPowerSupplyServiceClient powerSupplyServiceClient = new PowerSupplyServiceClient();

            var camera = ConnectToCamera(cameraServiceClient);

            var powerSupply = PowerSupplyDevice(powerSupplyServiceClient);

            StartStreaming(cameraServiceClient);

            PowerConsumptionTest(camera, powerSupply);
        }

        private static void PowerConsumptionTest(Camera camera, PowerSupplyDevice powerSupply)
        {
            msg = "Input acceptable range in Watts separated by comma ex. min,max: ";
            WriteToScreen(msg);
            var range = Console.ReadLine();

            if (range == null) throw new ArgumentNullException(range, "Range cannot be null");

            var lstRange = range.Split(',');


            IPowerConsumption powerConsumption = new PowerConsumption();

            camera.PowerConsumption = powerConsumption.PowerConsumptionInWatts(powerSupply);

            var passed = powerConsumption.IsPowerComsumptionWithinRange(Convert.ToDouble(lstRange[0]),
                Convert.ToDouble(lstRange[1]), camera);

            msg = passed ? "Test Passed!" : "Test Failed";
            WriteToScreen(msg);
        }

        private static void WriteToScreen(string msg)
        {
            Console.WriteLine(msg);
        }

        private static void StartStreaming(ICameraServiceClient cameraServiceClient)
        {
            cameraServiceClient.StartStreaming();
            msg = "camera started streaming......";
            WriteToScreen(msg);
        }

        private static PowerSupplyDevice PowerSupplyDevice(IPowerSupplyServiceClient powerSupplyServiceClient)
        {
            msg = "";

            foreach (var p in powerSupplyServiceClient.GetPowerSupplyDevices())
                msg += $"Com Port:{p.ComPort}\n";
            
            WriteToScreen(msg);

            WriteToScreen("Select a power supply by com port:");
            var comPort = Console.ReadLine();

            WriteToScreen($"Connecting to power supply on {comPort}.....");
            var powerSupply = powerSupplyServiceClient.Connect(comPort);

            WriteToScreen($"Connected to power supply on {powerSupply.ComPort}");

            return powerSupply;
        }

        private static Camera ConnectToCamera(ICameraServiceClient cameraServiceClient)
        {
            foreach (var c in cameraServiceClient.GetCameras()) Console.WriteLine("ID:{0} Name:{1}", c.Id, c.Name);

            Console.WriteLine("Select a camera by ID: ");
            var cameraId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Connecting to Camera {0}.....", cameraId);
            var camera = cameraServiceClient.Connect(cameraId);

            Console.WriteLine("connected to camera {0}\n\n", camera.Name);

            return camera;
        }
    }
}
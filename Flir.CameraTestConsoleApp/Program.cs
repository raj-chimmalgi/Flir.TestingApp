﻿using System;
using System.Collections.Generic;
using Flir.BusinessLayer;
using Flir.Entities;
using Flir.ServiceClient;

namespace Flir.CameraTestConsoleApp
{
    internal class Program
    {
        static string msg;

        static ConsoleLogger _consoleLogger = new ConsoleLogger();

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

            if (lstRange.Length != 2)
            {
                _consoleLogger.LogError("Invalid Range");
                throw new ArgumentException("Invalid acceptable power consumption range");     
            }


            IPowerConsumption powerConsumption = new PowerConsumption(new ConsoleLogger());
//            IPowerConsumption powerConsumption = new PowerConsumption(new FileLogger("C:\\Users\\chimm\\Desktop\\log.txt"));

            camera.PowerConsumption = powerConsumption.PowerConsumptionInWatts(powerSupply);

            var passed = powerConsumption.IsPowerConsumptionWithinRange(Convert.ToDouble(lstRange[0]),
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

            powerSupplyServiceClient.GetPowerSupplyDevices().ForEach(p => msg += $"Com Port:{p.ComPort}\n");
            
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
            msg = "";
            cameraServiceClient.GetCameras().ForEach(c => msg += $"ID:{c.Id} Name:{c.Name}\n");

            WriteToScreen(msg);

            Console.WriteLine("Select a camera by ID: ");
            var cameraId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Connecting to Camera {0}.....", cameraId);
            var camera = cameraServiceClient.Connect(cameraId);

            Console.WriteLine("connected to camera {0}\n\n", camera.Name);

            return camera;
        }
    }
}
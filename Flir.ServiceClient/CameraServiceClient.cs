using System;
using System.Collections.Generic;
using System.Linq;
using Flir.Entities;

namespace Flir.ServiceClient
{
    public class CameraServiceClient : ICameraServiceClient
    {
        private Camera connectedCamera;
        private List<Camera> lstCameras;

        public CameraServiceClient()
        {
            lstCameras = new List<Camera>();
            connectedCamera = new Camera();
        }

        public Camera Connect(int id)
        {
            try
            {
                lstCameras = GetCameras();
                connectedCamera = lstCameras.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                connectedCamera = null;
            }

            return connectedCamera;
        }

        public Camera Disconnect(int id)
        {
            try
            {
                connectedCamera = new Camera();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return connectedCamera;
        }

        public List<Camera> GetCameras()
        {
            lstCameras = new List<Camera>
            {
                new Camera {Id = 1, Name = "Cam1", PowerConsumption = null},
                new Camera {Id = 2, Name = "Cam2", PowerConsumption = null},
                new Camera {Id = 3, Name = "Cam3", PowerConsumption = null}
            };

            return lstCameras;
        }

        public bool StartStreaming()
        {
            return true;
        }

        public bool StopStreaming()
        {
            return true;
        }
    }
}
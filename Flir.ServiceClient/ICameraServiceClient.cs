using System.Collections.Generic;
using Flir.Entities;

namespace Flir.ServiceClient
{
    public interface ICameraServiceClient
    {
        List<Camera> GetCameras();
        Camera Connect(int id);
        Camera Disconnect(int id);
        bool StartStreaming();
        bool StopStreaming();
    }
}
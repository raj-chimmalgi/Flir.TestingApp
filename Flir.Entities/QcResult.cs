using System;

namespace Flir.Entities
{
    public class QcResult
    {
        public int Id { get; set; }
        public int CameraId { get; set; }
        public int PowerSupplyId { get; set; }
        public bool QcPassed { get; set; }
        public DateTime DateTested { get; set; }
    }
}
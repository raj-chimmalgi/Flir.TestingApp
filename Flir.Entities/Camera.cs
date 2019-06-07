using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Flir.Entities
{
    public class Camera
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? PowerConsumption { get; set; }
    }
}

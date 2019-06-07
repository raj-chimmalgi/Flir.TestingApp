using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Flir.Entities
{

    public class PowerSupplyDevice
    {
        public string ComPort { get; set; }
        public double Current { get; set; }
        public double Voltage { get; set; }
    }
}

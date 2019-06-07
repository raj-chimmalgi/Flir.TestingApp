using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flir.Entities;

namespace Flir.TestingApp.BusinessLayer
{
    public interface IPowerConsumption
    {
        double PowerConsumptionInWatts(PowerSupplyDevice powerSupplyDevice);

        bool IsPowerComsumptionWithinRange(double minWatts, double maxWatts, Camera camera);
    }
}

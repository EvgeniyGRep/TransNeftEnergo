using System.Collections.Generic;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class CalculatingMeter: IDbItem
    {
        public int Id { get; set; }

        public int PowerSupplyPointId { get; set; }
        public PowerSupplyPoint PowerSupplyPoint { get; set; }
        public List<PowerMeasuringPointToCalculatingMeter> PowerMeasuringPointToCalculatingMeter { get; set; }

        public CalculatingMeter()
        {
            PowerMeasuringPointToCalculatingMeter = new List<PowerMeasuringPointToCalculatingMeter>();
        }

        public IDbItem Initialize()
        {
            var item = new CalculatingMeter();    
            return item;
        }
    }
}

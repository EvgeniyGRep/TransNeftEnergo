using System;

namespace TransNeftEnergo.Models
{
    public class PowerMeasuringPointToCalculatingMeter
    {
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }

        public int PowerMeasuringPointId { get; set; }
        public virtual PowerMeasuringPoint PowerMeasuringPoint { get; set; }
        public int CalculatingMeterId { get; set; }
        public virtual CalculatingMeter CalculatingMeter { get; set; }

    }
}

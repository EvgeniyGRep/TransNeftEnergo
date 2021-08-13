using System;

namespace TransNeftEnergo.DTO
{
    public class CalculatingMeterDTO
    {
        public int Id { get; set; }
        public string PowerSupplyPointName { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
    }
}

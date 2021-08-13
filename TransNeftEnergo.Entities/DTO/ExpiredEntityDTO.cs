using System;

namespace TransNeftEnergo.DTO
{
    public class ExpiredEntityDTO : IdNumber
    {
        public string Type { get; set; }
        public DateTime InspectionDate { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}

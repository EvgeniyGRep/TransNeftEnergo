using System;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class CurrentMeter: IDbItem
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string MeterType { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionPeriod { get; set; }

        public PowerMeasuringPoint PowerMeasuringPoint { get; set; }

        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new CurrentMeter();

            item.Number = rnd.Next(0,100);
            item.MeterType = "Электронный";
            item.InspectionDate = new DateTime(2021, 1, 1).AddDays(rnd.NextDouble() * 100);
            item.InspectionPeriod = rnd.Next(0, 30);

            return item;
        }
    }
}

using System;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class CurrentTransformer: IDbItem
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string CurrentTransformerType { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionPeriod { get; set; }
        public double TransformationCoefficient { get; set; }

        public PowerMeasuringPoint PowerMeasuringPoint { get; set; }


        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new CurrentTransformer();

            item.Number = rnd.Next(0,50);
            item.CurrentTransformerType = "Измерительный";
            item.InspectionDate = new DateTime(2021, 1, 1).AddDays(rnd.NextDouble()*100);
            item.InspectionPeriod = rnd.Next(0, 30);
            item.TransformationCoefficient = rnd.NextDouble() * 100;

            return item;
        }
    }
}

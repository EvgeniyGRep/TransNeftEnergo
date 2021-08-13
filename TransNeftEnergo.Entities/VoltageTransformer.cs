using System;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class VoltageTransformer: IDbItem
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string VoltageTransformerType { get; set; }
        public DateTime InspectionDate { get; set; }
        public int InspectionPeriod { get; set; }
        public double TransformationCoefficient { get; set; }
        public PowerMeasuringPoint PowerMeasuringPoint { get; set; }


        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new VoltageTransformer();

            item.Number = rnd.Next(0, 50);
            item.InspectionDate = new DateTime(2021, 1, 1).AddDays(rnd.NextDouble() * 100);
            item.InspectionPeriod = rnd.Next(0, 30);
            item.VoltageTransformerType = "Двухобмоточный";
            item.TransformationCoefficient = rnd.NextDouble() * 100;


            return item;
        }
    }
}

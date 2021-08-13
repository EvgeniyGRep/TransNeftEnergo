using System;
using System.Collections.Generic;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class ConsumptionObject: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set;}
        public string Address { get; set; }

        public int ChildOrganizationId { get; set; }
        public ChildOrganization ChildOrganization { get; set; }
        public List<PowerSupplyPoint> PowerSupplyPoints { get; set; }
        public List<PowerMeasuringPoint> PowerMeasuringPoints { get; set; }

        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new ConsumptionObject();

            item.Address = $"Улица {rnd.Next(0, 5000)}";
            item.Name = $"Станция {rnd.Next(0, 5000)}";
            item.PowerMeasuringPoints = new List<PowerMeasuringPoint>()
            {
                new PowerMeasuringPoint().Initialize() as PowerMeasuringPoint,
                new PowerMeasuringPoint().Initialize() as PowerMeasuringPoint,
                new PowerMeasuringPoint().Initialize() as PowerMeasuringPoint
            };
            item.PowerSupplyPoints = new List<PowerSupplyPoint>()
            {
                new PowerSupplyPoint().Initialize() as PowerSupplyPoint,
                new PowerSupplyPoint().Initialize() as PowerSupplyPoint,
                new PowerSupplyPoint().Initialize() as PowerSupplyPoint
            };


            //Инициализация связи по интервалу времени
            foreach (var pmp in item.PowerMeasuringPoints)
            {
                var date = new DateTime(rnd.Next(2017, 2021), 1, 1).AddDays(rnd.NextDouble() * 100);
                pmp.PowerMeasuringPointToCalculatingMeters.Add(new PowerMeasuringPointToCalculatingMeter()
                {

                    PowerMeasuringPoint = pmp,
                    CalculatingMeter = item.PowerSupplyPoints[rnd.Next(0, item.PowerSupplyPoints.Count)].CalculatingMeter,
                    FromTime = date,
                    ToTime = date.AddDays(rnd.NextDouble()*100)
                }) ;
            } 

            return item;

        }
    }
}

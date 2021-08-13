using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class PowerMeasuringPoint: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<PowerMeasuringPointToCalculatingMeter> PowerMeasuringPointToCalculatingMeters { get; set; }
        public int ConsumptionObjectId { get; set; }
        public ConsumptionObject ConsumptionObject { get; set; }
        [ForeignKey("CurrentMeterId")]
        public CurrentMeter CurrentMeter { get; set; }
        [ForeignKey("CurrentTransformerId")]
        public CurrentTransformer CurrentTransformer { get; set; }
        [ForeignKey("VoltageTransformerId")]
        public VoltageTransformer VoltageTransformer { get; set; }

        public PowerMeasuringPoint()
        {
            PowerMeasuringPointToCalculatingMeters = new List <PowerMeasuringPointToCalculatingMeter>();
        }

        public IDbItem Initialize()
        {
            
            var rnd = new Random();
            var item = new PowerMeasuringPoint();

            item.Name = $"Точка измерения электроэнергии {rnd.Next(0, 5000)}";
            item.CurrentTransformer = new CurrentTransformer().Initialize() as CurrentTransformer;
            item.CurrentMeter = new CurrentMeter().Initialize() as CurrentMeter; 
            item.VoltageTransformer = new VoltageTransformer().Initialize() as VoltageTransformer;

            return item;

        }
            
    }
}

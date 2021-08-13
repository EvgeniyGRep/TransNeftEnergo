using System;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class PowerSupplyPoint: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double MaximumPower { get; set; }

        public int ConsumptionObjectId { get; set; }
        public ConsumptionObject ConsumptionObject { get; set; }
        public CalculatingMeter CalculatingMeter { get; set; }

        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new PowerSupplyPoint();

            item.Name = $"Точка поставки энергии {rnd.Next(0,5000)}";
            item.MaximumPower = rnd.NextDouble() * 100;
            item.CalculatingMeter = new CalculatingMeter().Initialize() as CalculatingMeter;

            return item;
        }
    }
}

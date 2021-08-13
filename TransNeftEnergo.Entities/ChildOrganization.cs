using System;
using System.Collections.Generic;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class ChildOrganization: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public List<ConsumptionObject> ConsumptionObjects { get; set; }

        public IDbItem Initialize()
        {
            var rnd = new Random();
            var item = new ChildOrganization();

            item.Address = $"Улица {rnd.Next(0,5000)}";
            item.Name = $"Компания {rnd.Next(0,5000)}";
            item.ConsumptionObjects = new List<ConsumptionObject>()
            {
                new ConsumptionObject().Initialize() as ConsumptionObject,
                new ConsumptionObject().Initialize() as ConsumptionObject,
                new ConsumptionObject().Initialize() as ConsumptionObject,
            };
            return item;
        }
    }
}

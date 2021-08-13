using System.Collections.Generic;
using TransNeftEnergo.Mock;

namespace TransNeftEnergo.Models
{
    public class Organization: IDbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<ChildOrganization> ChildOrganizations { get; set; }

        public IDbItem Initialize()
        {
            var item = new Organization();

            item.Name = "Орагнизация 1";
            item.Address = "Улица 1";
            item.ChildOrganizations = new List<ChildOrganization>()
            { 
                new ChildOrganization().Initialize() as ChildOrganization,
                new ChildOrganization().Initialize() as ChildOrganization,
                new ChildOrganization().Initialize() as ChildOrganization 
            };

            return item;
        }
    }
}

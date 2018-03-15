using System.Collections.Generic;
using System.Collections.ObjectModel;
using VEGA.Models;

namespace VEGA.Controllers.Resources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValueFairResource Model { get; set; }
        public KeyValueFairResource Make { get; set; }
        public bool IsRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public ICollection<KeyValueFairResource> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<KeyValueFairResource>();
        }
    }
}
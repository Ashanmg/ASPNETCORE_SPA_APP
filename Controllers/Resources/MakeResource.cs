using System.Collections.Generic;
using System.Collections.ObjectModel;
using VEGA.Models;

namespace VEGA.Controllers.Resources
{
    public class MakeResource : KeyValueFairResource
    {
        public ICollection<KeyValueFairResource> Models { get; set; }

        public MakeResource()
        { 
            Models = new Collection<KeyValueFairResource>();
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace vega.Controllers.Resources
{
    public class MakeResources
    {
      
        public int id {get;set;}
        
        public string name {get;set;}

        public ICollection<ModelResources> Models {get;set;}

        public MakeResources()
        {
            Models= new Collection<ModelResources>();
        }
        
    
    }
}
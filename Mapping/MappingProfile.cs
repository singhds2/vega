using AutoMapper;
using vega.Controllers.Resources;
using vega.Models;

namespace vega.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
         CreateMap<Make,MakeResources>();  
         CreateMap<Model,ModelResources>(); 
        }
    }
}
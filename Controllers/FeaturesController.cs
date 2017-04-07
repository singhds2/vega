using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using vega.Persistence;
using vega.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace vega.Controllers
{
    public class FeaturesController:Controller
    {


        private readonly VegaDbContext context;

        public FeaturesController(VegaDbContext context, IMapper mapper)

        {
            this.context = context;


        }


        [HttpGet("/api/features")]
        public async Task<IEnumerable<Feature>> GetFeatures()
        {
            return  await  context.Features.ToListAsync();
          //   var makes=  await  context.Makes.ToListAsync();
         
        }

        
    }
}
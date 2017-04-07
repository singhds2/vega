
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vega.Models;
using vega.Persistence;
using AutoMapper;
using vega.Controllers.Resources;

namespace vega.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;

        public MakesController(VegaDbContext context, IMapper mapper)

        {
            this.context = context;


        }


        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakeResources>> GetMakes()
        {
            var makes=  await  context.Makes.Include(m=> m.Models).ToListAsync();
          //   var makes=  await  context.Makes.ToListAsync();
            return Mapper.Map<List<Make>,List<MakeResources>>(makes);
        }

    }
}
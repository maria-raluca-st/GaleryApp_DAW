using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_proiect.DAL;

namespace WebApplication_proiect.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        private AppDbContext _context;

        public LocationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-join-linq")]
        public async Task<IActionResult> GetJoinLinq()
        {
            var locations = _context.Locations;
            var join = _context.Galleries.Join(locations, b => b.LocationId, a => a.Id, (b, a) => new
            {
                b.LocationId,
                b.Name,
                a.Street,
                a.StreetNumber
            }).ToList();

            return Ok(join);
        }
    }
}

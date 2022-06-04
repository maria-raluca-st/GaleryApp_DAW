using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_proiect.DAL;
using WebApplication_proiect.DAL.Entities;

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

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> DeleteLocation([FromRoute] int id)
        {
            var location = await _context.Locations.FindAsync(id);
            if (location == null)
            {
                return NotFound();
            }

            _context.Locations.Remove(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {

            if (string.IsNullOrEmpty(location.Street))
            {
                return BadRequest("Street is null!");
            }

            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string street)
        {
            var location = await _context.Locations.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            location.Street = street;

            _context.Entry(location).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var locationV2 = await _context.Locations.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }
    }
}

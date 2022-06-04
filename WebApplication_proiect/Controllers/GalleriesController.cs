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
    public class GalleriesController : ControllerBase
    {

        private AppDbContext _context;
        public GalleriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("get-select")]
        public async Task<IActionResult> GetExhibitionsSelect()
        {
            var exhibitions = await _context.Exhibitions.Select(x => new { Id = x.Id , Name = x.Name}).ToListAsync();
            
            return Ok(exhibitions);
        }

        [HttpGet("get-join")]
        public async Task<IActionResult> GetGalleryExhibitionsJoin()
        {
            var gallery = await _context
                .Galleries
                .Include(x => x.Exhibitions)
                .Where(x => x.Exhibitions.Count >= 1)
                .ToListAsync();

            return Ok(gallery);
        }


        [HttpGet("get-orderby")]
        public async Task<IActionResult> GetGalleryExhibitionsOrderBy()
        {

            var gallery = await _context
                .Galleries
                .Include(x => x.Exhibitions)
                .Where(x => x.Exhibitions.Count >= 1)
                .OrderByDescending(x => x.Name)
                .Select(x => x.Name)
                .ToListAsync();

            return Ok(gallery);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGallery([FromRoute] int id)
        {
            var gallery = await _context.Galleries.FindAsync(id);
            if (gallery == null)
            {
                return NotFound();
            }

            _context.Galleries.Remove(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("AddGallery")]
        public async Task<IActionResult> AddGallery([FromBody] Gallery gallery)
        {

            if (string.IsNullOrEmpty(gallery.Name))
            {
                return BadRequest("Name is null!");
            }

            await _context.Galleries.AddAsync(gallery);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            var gallery = await _context.Galleries.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            gallery.Name = name;

            _context.Entry(gallery).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var galleryV2 = await _context.Galleries.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }

    }
}

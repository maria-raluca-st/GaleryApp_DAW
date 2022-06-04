using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_proiect.DAL;

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

    }
}

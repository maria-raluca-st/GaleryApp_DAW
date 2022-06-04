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
    public class PhotographersController : ControllerBase
    {
       
        private AppDbContext _context;

        public PhotographersController(AppDbContext context) 
        {
            _context = context;
        }
        [HttpPost("AddPhotographer")]
        public async Task<IActionResult>AddPhotographer([FromBody] Photographer photographer)
        {

            //var context = new AppDbContext();
            //var service = new ServiceFilterAttribute(context);
            if(string.IsNullOrEmpty(photographer.Name))
            {
                return BadRequest("Name is null!");
            }

            await _context.Photographers.AddAsync(photographer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> GetPhotographer([FromRoute] int id)
        {
            var photographer = await _context.Photographers.Where(x => x.Id == id).FirstOrDefaultAsync();

            return Ok(photographer);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] int id, [FromQuery] string name)
        {
            var photographer = await _context.Photographers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            photographer.Name = name;

            //_context.Students.Attach(student);
            _context.Entry(photographer).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            var photographerV2 = await _context.Photographers.FirstOrDefaultAsync(x => x.Id == id);

            return Ok();
        }


        [HttpGet("jazy-lazy")]
        public async Task<IActionResult> JoinLazy()
        {
            var photographers = _context.Photographers.AsQueryable();
            var photographersList = photographers.ToList();

            return Ok(photographers);
        }

        [HttpGet("get-group-by")]
        public async Task<IActionResult> GetGroupBy()
        {
            var exhibitionsByPhotographer = _context.PhotographerExhibitions.GroupBy(x => x.PhotographerId).Select(x => new
            {
                Key = x.Key,
                Count = x.Count()
            }).ToList();

            return Ok(exhibitionsByPhotographer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhotographer([FromRoute] int id)
        {
            var photographer = await _context.Photographers.FindAsync(id);
            if (photographer == null)
            {
                return NotFound();
            }

            _context.Photographers.Remove(photographer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

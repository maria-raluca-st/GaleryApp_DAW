using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Interfaces;
using WebApplication_proiect.DAL.Models;

namespace WebApplication_proiect.DAL.Repositories
{
    public class PhotographerRepository : IPhotographerRepository
    {
        private readonly AppDbContext _context;

        public PhotographerRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Photographer photographer)
        {
            await _context.Photographers.AddAsync(photographer);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Photographer photographer)
        {
            _context.Photographers.Remove(photographer);
            await _context.SaveChangesAsync();
        }

        public async Task<Photographer> GetById(int id)
        {
            var photographer = await _context.Photographers.FindAsync(id);
            return photographer;
        }

        public async Task Update(Photographer photographer)
        {
             _context.Photographers.Update(photographer);
            await _context.SaveChangesAsync();
        }

        public async Task<IQueryable<PhotographerModels>> GetAllQuery()
        {
            var query = _context.Photographers.AsQueryable();

            return (IQueryable<PhotographerModels>)query;
        }

        public async Task<List<PhotographerModels>> GetAll()
        {
            //var photographers = await(await GetAllQuery()).ToListAsync();
            //return photographers;
            return new List<PhotographerModels>();
        }

    }
}

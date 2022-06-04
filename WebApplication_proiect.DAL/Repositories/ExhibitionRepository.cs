using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.DAL.Repositories
{
    public class ExhibitionRepository : IExhibitionRepository
    {
        private readonly AppDbContext _context;
        public ExhibitionRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Create(Exhibition exhibition)
        {
            await _context.Exhibitions.AddAsync(exhibition);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Exhibition exhibition)
        {
            _context.Exhibitions.Remove(exhibition);
            await _context.SaveChangesAsync();
        }

        public Task<List<Exhibition>> GetAll()
        {
            var query = _context.Exhibitions.AsQueryable();

            return (Task<List<Exhibition>>)query;
        }

        public async Task<Exhibition> GetById(int id)
        {
            var exhibition = await _context.Exhibitions.FindAsync(id);
            return exhibition;
        }

        public async Task Update(Exhibition exhibition)
        {
            _context.Exhibitions.Update(exhibition);
            await _context.SaveChangesAsync();
        }
    }
}

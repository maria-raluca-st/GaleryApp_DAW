using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.DAL.Repositories
{
    public class GalleryRepository : IGalleryRepository
    {


        private readonly AppDbContext _context;
        public GalleryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Gallery>> GetGalleryExhibitionsJoin()
        {
            var gallery = await _context
                .Galleries
                .Include(x => x.Exhibitions)
                .Where(x => x.Exhibitions.Count >= 1)
                .ToListAsync();

             return gallery;
        }
    }
}

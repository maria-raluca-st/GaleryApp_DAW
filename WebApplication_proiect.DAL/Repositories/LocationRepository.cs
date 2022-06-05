using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.DAL.Repositories
{
    public class LocationRepository : ILocationRepository
    {
        private readonly AppDbContext _context;
        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Location> GetJoinLinq()
        {
            var locations = _context.Locations;
            var join = _context.Galleries.Join(locations, b => b.LocationId, a => a.Id, (b, a) => new
            {
                b.LocationId,
                b.Name,
                a.Street,
                a.StreetNumber
            }).ToList();

            return join;
        }
    }
}

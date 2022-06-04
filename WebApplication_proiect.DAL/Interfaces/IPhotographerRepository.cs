using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;
using WebApplication_proiect.DAL.Models;

namespace WebApplication_proiect.DAL.Interfaces
{
    public interface IPhotographerRepository
    {
        Task<List<PhotographerModels>> GetAll();
        Task<Photographer> GetById(int id);
        Task Create(Photographer photographer);
        Task Update(Photographer photographer);
        Task Delete(Photographer photographer);
 
    }
}

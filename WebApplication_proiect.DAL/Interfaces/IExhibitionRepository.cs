using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.DAL.Entities;

namespace WebApplication_proiect.DAL.Interfaces
{
    public interface IExhibitionRepository
    {
        Task<List<Exhibition>> GetAll();
        Task<Exhibition> GetById(int id);
        Task Create(Exhibition photographer);
        Task Update(Exhibition photographer);
        Task Delete(Exhibition photographer);
    }
}

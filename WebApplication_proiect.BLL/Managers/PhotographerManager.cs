using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.BLL.Interfaces;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.BLL.Managers
{
    public class PhotographerManager : IPhotographerManager
    {
        private readonly IPhotographerRepository _photographerRepo;

        public PhotographerManager(IPhotographerRepository photographerRepo)
        {
            _photographerRepo = photographerRepo;
        }
        public async Task<List<string>> ModifyPhotographer()
        {
            var photographers = await _photographerRepo.GetAll();
            var list = new List<string>();

            foreach (var photographer in photographers)
            {
                list.Add($"PhotographerName: {photographer.Name}");
            }

            return list;
        }
    }
}

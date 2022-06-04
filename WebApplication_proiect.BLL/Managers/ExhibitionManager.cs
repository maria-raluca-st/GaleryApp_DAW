using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication_proiect.BLL.Interfaces;
using WebApplication_proiect.DAL.Interfaces;

namespace WebApplication_proiect.BLL.Managers
{
    public class ExhibitionManager : IExhibitionManager
    {
        private readonly IExhibitionRepository _exhibitionRepo;

        public ExhibitionManager(IExhibitionRepository exhibitionRepo)
        {
            _exhibitionRepo = exhibitionRepo;
        }
        public async Task<List<string>> ModifyExhibition()
        {
            var exhibitions = await _exhibitionRepo.GetAll();
            var list = new List<string>();

            foreach (var exhibition in exhibitions)
            {
                list.Add($"ExhibitionName: {exhibition.Name}");
            }

            return list;
        }
    }
}

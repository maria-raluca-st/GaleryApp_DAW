using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.BLL.Interfaces
{
    public interface IExhibitionManager
    {
        Task<List<string>> ModifyExhibition();
    }
}

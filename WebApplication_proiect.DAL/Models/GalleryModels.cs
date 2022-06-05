using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Models
{
    public class GalleryModels
    {
        public string Name { get; set; }
        public virtual ICollection<ExhibitionModels> Exhibitions { get; set; }
    }
}

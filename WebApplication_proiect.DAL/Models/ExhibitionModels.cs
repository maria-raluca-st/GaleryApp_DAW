using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Models
{
    public class ExhibitionModels
    {
        public string Name { get; set; }
        public string Theme { get; set; }

        //public int? GalleryId { get; set; }

        public virtual GalleryModels Gallery { get; set; }
    }
}

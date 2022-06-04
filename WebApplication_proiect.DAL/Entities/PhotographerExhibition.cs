using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class PhotographerExhibition
    {
        public int Id { get; set; }
        public int PhotographerId { get; set; }
        public int ExhibitionId { get; set; }

        public virtual Photographer Photographer { get; set; }
        public virtual Exhibition Exhibition { get; set; }

    }
}

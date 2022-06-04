using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class Exhibition
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Theme { get; set; }

        public int? GalleryId { get; set; }

        public virtual Gallery Gallery { get; set; }

        public virtual ICollection<PhotographerExhibition> PhotographerExhibitions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class Photographer
    {
        // daca punem [Key] spunem explicit ca ce vine dupa e primary key
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string PhotographyType { get; set; }
        public string Equipment { get; set; }

        public virtual ICollection<PhotographerExhibition> PhotographerExhibitions { get; set; }

    }
}

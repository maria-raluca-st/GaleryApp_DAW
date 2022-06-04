using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }

        public virtual ICollection<Exhibition> Exhibitions { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Entities
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public int StreetNumber { get; set; }
        public string Building { get; set; }
        public virtual Gallery Galery { get; set; }
    }
}

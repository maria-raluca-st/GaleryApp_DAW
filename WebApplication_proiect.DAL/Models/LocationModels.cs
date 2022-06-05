using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication_proiect.DAL.Models
{
    public class LocationModels
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string Building { get; set; }
    }
}

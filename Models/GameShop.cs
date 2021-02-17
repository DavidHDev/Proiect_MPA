using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MPA.Models
{
    public class GameShop
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PriceRange { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}
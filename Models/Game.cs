using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MPA.Models
{
    public class Game
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GameID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ICollection<Store> Stores { get; set; }
    }
}

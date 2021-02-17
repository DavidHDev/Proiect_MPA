using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_MPA.Models
{
    public class Store
    {   
        public int StoreID { get; set; }
        public int GameShopID { get; set; }
        public int GameID { get; set; }

        public GameShop GameShop { get; set; }
        public Game Game { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Proiect_MPA.Models;
namespace Proiect_MPA.Data
{
    public class DbInitializer
    {
        public static void Initialize(MagazinContext context)
        {
            context.Database.EnsureCreated();
            if (context.GameShops.Any())
            {
                return; // BD a fost creata anterior
            }
            var GameShops = new GameShop[]
            {
new GameShop{Name="Popescu Maria",Location="Cluj-Napoca, strada Aurel Vlaicu, numarul 4 ",PriceRange="2500 lei"},
new GameShop{Name="Popa Florin",Location="Cluj-Napoca, Nicolae Balcescu, numarul 2 ",PriceRange="2100 lei"},
new GameShop{Name="Marinescu Iulia", Location="Cluj-Napoca, strada Horea, numarul 5 ",PriceRange="2700 lei"},
            };
            foreach (GameShop s in GameShops)
            {
                context.GameShops.Add(s);
            }
            context.SaveChanges();
            var Games = new Game[]
            {
new Game{GameID=1050,Name="Paine",Price=Decimal.Parse("4")},
new Game{GameID=1045,Name="Faina",Price=Decimal.Parse("5")},
new Game{GameID=1040,Name="Zahar",Price=Decimal.Parse("3")},
            };
            foreach (Game c in Games)
            {
                context.Games.Add(c);
            }
            context.SaveChanges();
            var stores = new Store[]
            {
new Store{GameShopID=1,GameID=1050},
new Store{GameShopID=3,GameID=1045},
new Store{GameShopID=1,GameID=1040},
new Store{GameShopID=2,GameID=1050},
            };
            foreach (Store e in stores)
            {
                context.Stores.Add(e);
            }
            context.SaveChanges();
        }
    }
}
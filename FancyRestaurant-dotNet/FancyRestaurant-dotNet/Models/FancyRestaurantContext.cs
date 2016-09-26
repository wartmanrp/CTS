using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace FancyRestaurant.Models
{
   //TODO set up context
   public class FancyRestaurantContext
   {

      public void SaveChanges()
      {

      }
      public DbSet<Reservation> Reservations { get; set; }
   }
}
//   public class FancyRestaurantContext : DbContext
//   {
//      private readonly IConfigurationRoot _config;

//      public FancyRestaurantContext(IConfigurationRoot config, DbContextOptions options) : base(options)
//      {
//         _config = config;
//      }

//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//      {
//         base.OnConfiguring(optionsBuilder);

//         optionsBuilder.UseSqlServer(_config["Data:FancyRestaurantContext"]);
//      }

//      public DbSet<Reservation> Reservations { get; set; }
//   }
//}

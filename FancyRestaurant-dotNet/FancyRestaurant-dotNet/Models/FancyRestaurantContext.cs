using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.Extensions.Configuration;


namespace FancyRestaurant.Models
{
   public class FancyRestaurantContext : DbContext
   {
      public FancyRestaurantContext() {}

      public static FancyRestaurantContext Create()
      {
         return new FancyRestaurantContext();
      }
      public DbSet<Reservation> Reservations { get; set; }

      }
   }

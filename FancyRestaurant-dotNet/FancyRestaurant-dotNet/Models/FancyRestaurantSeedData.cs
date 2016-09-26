using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyRestaurant.Models
{
   public class FancyRestaurantSeedData
   {
      private FancyRestaurantContext _context;

      public FancyRestaurantSeedData(FancyRestaurantContext context)
      {
         _context = context;
      }

      public void EnsureSeedData()
      {
         if (!_context.Reservations.Any())
         {
            var reservations = new List<Reservation>()
                {
                    new Reservation()
                    {
                        Name = "Helms",
                        Seats = 4,
                        Phone = "123-456-7890",
                        ReservationDateTime = DateTime.Parse("09-22-2016 10:00:00 AM")
                    },
                    new Reservation()
                    {
                        Name = "Mukkai",
                        Seats = 5,
                        Phone = "123-456-7890",
                        ReservationDateTime = DateTime.Parse("09-22-2016 12:00:00 PM")
                    },
                    new Reservation()
                    {
                        Name = "Wartman",
                        Seats = 3,
                        Phone = "123-456-7890",
                        ReservationDateTime = DateTime.Parse("09-22-2016 11:00:00 AM")
                    }
                };

            _context.Reservations.AddRange(reservations);
            _context.SaveChanges();
         }
      }
   }
}

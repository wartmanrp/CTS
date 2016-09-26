using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FancyRestaurant.Models
{
   public class ReservationRepository : IReservationRepository
   {
      private FancyRestaurantContext _context;

      public ReservationRepository(FancyRestaurantContext context)
      {
         _context = context;
      }

      public IEnumerable<Reservation> Reservations => _context.Reservations;

      public void Save(Reservation reservation)
      {
         if (reservation.Id == 0)
         {
            _context.Reservations.Add(reservation);
         }
         else
         {
            var dbEntry = _context.Reservations.FirstOrDefault(r => r.Id == reservation.Id);

            if (dbEntry != null)
            {
               dbEntry.Name = reservation.Name;
               dbEntry.Phone = reservation.Phone;
               dbEntry.Seats = reservation.Seats;
               dbEntry.ReservationDateTime = reservation.ReservationDateTime;
            }
         }
         _context.SaveChanges();
      }

      public Reservation Delete(int id)
      {
         var dbEntry = _context.Reservations.FirstOrDefault(r => r.Id == id);

         if (dbEntry != null)
         {
            _context.Reservations.Remove(dbEntry);
            _context.SaveChanges();
         }
         return dbEntry;
      }
   }
}

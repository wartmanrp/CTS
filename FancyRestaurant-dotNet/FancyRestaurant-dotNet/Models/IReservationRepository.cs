using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FancyRestaurant.Models
{
   public interface IReservationRepository
   {
      IEnumerable<Reservation> Reservations { get; }

      void Save(Reservation reservation);
      Reservation Delete(int id);
   }
}

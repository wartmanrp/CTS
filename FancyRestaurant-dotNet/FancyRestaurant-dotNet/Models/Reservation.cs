using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FancyRestaurant.Models
{
   public class Reservation
   {
      [HiddenInput(DisplayValue = false)]
      public int Id { get; set; }
      [StringLength(25, MinimumLength = 2)]
      public string Name { get; set; }
      [Phone]
      public string Phone { get; set; }
      public int Seats { get; set; }
      public DateTime ReservationDateTime { get; set; }
   }
}

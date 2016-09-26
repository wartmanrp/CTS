using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FancyRestaurant.Models;
using System.Web.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FancyRestaurant.Controllers
{
   public class AppController : Controller
   {

      private FancyRestaurantContext Db = new FancyRestaurantContext();


      public AppController()
      {
      }

      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Details(int id)
      {
         var reservation = Db.Reservations.FirstOrDefault(r => r.Id == id);

         return View(reservation);
      }

      public ActionResult MakeReservation()
      {
         return View("Edit", new Reservation());
      }

      public ActionResult Edit(int id)
      {
         var reservation = Db.Reservations.FirstOrDefault(r => r.Id == id);

         return View(reservation);
      }

      [HttpPost]
      public ActionResult Edit(Reservation reservation)
      {
         if (ModelState.IsValid)
         {
            Reservation newReservation = new Reservation();
            if (reservation.Id > 0)
            {
               newReservation.Id = reservation.Id;
               Db.Reservations.Attach(newReservation);
            } else
            {
               Db.Reservations.Add(newReservation);
            }

            newReservation.Name = reservation.Name;
            newReservation.Phone = reservation.Phone;
            newReservation.Seats = reservation.Seats;
            newReservation.ReservationDateTime = reservation.ReservationDateTime;

            Db.SaveChanges();

            ModelState.Clear();
            ViewBag.MessageType = "success";
            ViewBag.Message = "Reservation updated successfully";
            return RedirectToAction("Index");
         }
         else
         {
            ViewBag.MessageType = "error";
            ViewBag.Message = "Something is wrong with the data values";
            return View(reservation);
         }
      }

      [HttpPost]
      public ActionResult Delete(int id)
      {
         var deletedReservation = Db.Reservations.Find(id);

         if (deletedReservation != null)
         {
            Db.Reservations.Remove(deletedReservation);
            ViewBag.MessageType = "success";
            ViewBag.Message = string.Format("Reservation for {0}, party of {1} for {2} was successfully deleted",
                deletedReservation.Name, deletedReservation.Seats, deletedReservation.ReservationDateTime);
            Db.SaveChanges();
         }
         return RedirectToAction("Index");
      }

      public ActionResult Reservations()
      {
         return View(Db.Reservations);
      }
   }
}

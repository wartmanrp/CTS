using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FancyRestaurant.Models;
using System.Web.Mvc;

namespace FancyRestaurant.Controllers
{
   public class AppController : Controller
   {
      private IReservationRepository _repository;
      public AppController()
      {
      }

      public ActionResult Index()
      {
         return View();
      }

      public ActionResult Details(int id)
      {
         var reservation = _repository.Reservations.FirstOrDefault(r => r.Id == id);

         return View(reservation);
      }

      public ActionResult MakeReservation()
      {
         return View("Edit", new Reservation());
      }

      public ActionResult Edit(int id)
      {
         var reservation = _repository.Reservations.FirstOrDefault(r => r.Id == id);

         return View(reservation);
      }

      [HttpPost]
      public ActionResult Edit(Reservation reservation)
      {
         if (ModelState.IsValid)
         {
            _repository.Save(reservation);

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
         var deletedReservation = _repository.Delete(id);

         if (deletedReservation != null)
         {
            ViewBag.MessageType = "success";
            ViewBag.Message = string.Format("Reservation for {0}, party of {1} for {2} was successfully deleted",
                deletedReservation.Name, deletedReservation.Seats, deletedReservation.ReservationDateTime);
         }
         return RedirectToAction("Index");
      }

      public ActionResult Reservations()
      {
         return View(_repository.Reservations);
      }
   }
}

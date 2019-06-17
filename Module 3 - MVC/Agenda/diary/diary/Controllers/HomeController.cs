using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diary.Models;

namespace diary.Views
{
    public class HomeController : Controller
    {
        agendaEntities1 db = new agendaEntities1();
        // GET: Home | Affiche la liste des rendez-vous
        public ActionResult Index()
        {
            var appointmentsList = db.appointments.ToList().OrderBy(x => x.datHour);
            return View("Index", appointmentsList);
        }
        // GET: DeleteAppointment | Permet de supprimer un rdv
        public ActionResult DeleteAppointment(int? id)
        {
            if (id == null)
            {
                return View("Error404");
            }
            else
            {
                appointment appointmentToDelete = db.appointments.Find(id);
                db.appointments.Remove(appointmentToDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}
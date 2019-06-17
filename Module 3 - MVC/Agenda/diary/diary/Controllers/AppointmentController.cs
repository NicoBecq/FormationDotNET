using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using diary.Models; // ajout du modèle

namespace diary.Controllers
{
    public class AppointmentController : Controller
    {
        private agendaEntities1 db = new agendaEntities1(); // nouvelle instance du model de la bdd
        // GET: AddAppointment | Affiche la page d'ajout d'un rendez-vous
        [HttpGet]
        public ActionResult AddAppointment(int? id)
        {
            if (id != null)
            {
                ViewBag.SelectedBroker = id;
            }
            // select query
            var selectBrokerQuery = from m in db.brokers
                                    select m;
            // passage de résultat sous forme de liste dans le viewbag
            ViewBag.ListBrokers = new SelectList(selectBrokerQuery, "idBroker", "lastName", ViewBag.SelectedBroker);
            // select query
            var selectCustomerQuery = from m in db.customers
                                      select m;
            // passage de résultat sous forme de liste dans le viewbag
            ViewBag.ListCustomers = new SelectList(selectCustomerQuery, "idCustomer", "lastName");
            return View("AddAppointment");
        }
        // POST: AddAppointment | ajoute un rendez-vous dans la bdd
        [HttpPost]
        public ActionResult AddAppointment(int? id, appointment newAppointment)
        {
            // si le rdv est fixé à une datetime supérieure à celle d'ajourd'hui, permettre l'insertion
            if (newAppointment.datHour > DateTime.Now)
            {
                // si l'heure choisie est inférieure à 8 heures, message d'erreur
                if (newAppointment.datHour.Hour < 8)
                {
                    // message d'erreur dans une alert js et retour à la dernière page
                    return Content("<script type='text/javascript'>alert('Les rendez-vous commencent à 8 heures.'); history.back();</script>");
                }
                // si l'heure choisie est supérieure à 18 heures, message d'erreur
                if (newAppointment.datHour.Hour > 18)
                {
                    // message d'erreur dans une alert js et retour à la dernière page
                    return Content("<script type='text/javascript'>alert('Les rendez-vous finissent à 18 heures.'); history.back();</script>");
                }
                // tranches horaires 
                //DateTime addHour = newAppointment.datHour.AddHours(1);
                //var timeSpot = db.appointments.Where(x => x.idBroker == newAppointment.idBroker).Where(x => x.datHour >= newAppointment.datHour & x.datHour <= addHour).SingleOrDefault();

                // si le rdv avec ce broker existe pas dans la dbb, message d'erreur
                if (db.appointments.Any(x => x.idBroker == newAppointment.idBroker) && db.appointments.Any(x => x.datHour == newAppointment.datHour))
                {
                    // message d'erreur dans une alert js et retour à la dernière page
                    return Content("<script type='text/javascript'>alert('Le courtier a déjà un rendez vous pour le crénaux horaire spécifié.'); history.back();</script>");
                }
                
                // sinon insert into
                else
                {
                    // insert into query
                    string insertAppointmentQuery = "INSERT INTO [dbo].[appointments]([datHour], [subject], [idBroker], [idCustomer])" +
                                        "VALUES ('" + newAppointment.datHour + "', '" + newAppointment.subject + "', " + newAppointment.idBroker + ", " + newAppointment.idCustomer + ");";
                    db.Database.ExecuteSqlCommand(insertAppointmentQuery); // execution de la query
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
            }
            // sinon, renvoyer message d'erreur
            else
            {
                return Content("<script type='text/javascript'>Swal.fire('Vous ne pouvez pas prendre de rendez-vous pour une date passée.'); history.back();</script>");
            }
        }
    }
}
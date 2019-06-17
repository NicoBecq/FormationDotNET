using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using diary.Models; // ajout du modèle

namespace diary.Controllers
{
    public class BrokerController : Controller
    {
        private agendaEntities1 db = new agendaEntities1(); // nouvelle instance du modèle bdd
        // GET: Broker | Méthode permettant d'afficher le formulaire d'ajout de courtier
        public ActionResult AddBroker()
        {
            return View("AddBroker");
        }
        // POST: Broker | Méthode permettant d'ajouter un courtier dans la bdd lors d'un POST
        [HttpPost] 
        public ActionResult AddBroker(broker newBroker)
        {
            using(db) 
            {
                // si lastName ET firstName éxistent dans la base, afficher message d'erreur
                if ((db.brokers.Any(x => x.lastName == newBroker.lastName) && db.brokers.Any(x => x.firstName == newBroker.firstName)) || db.brokers.Any(x => x.mail == newBroker.mail))
                {
                    ViewBag.DuplicateMessage = "Le courtier que vous essayez d'ajouter existe déjà dans la base de données";
                    return View("AddBroker");
                }
                // sinon INSERT INTO
                else
                {
                    db.brokers.Add(newBroker); // INSERT INTO db l'objet broker
                    db.SaveChanges(); // sauvegarde dans la bdd
                    ViewBag.SuccesMessage = "Courtier ajouté";
                }
            }
            ModelState.Clear(); // supprime les erreurs du model
            return View("AddBroker");
        }
        // GET: ListBroker | Méthode permettant d'afficher la liste des courtiers
        public ActionResult ListBrokers()
        {
            // requête linq
            var brokersList = from m in db.brokers
                              select m;
            ModelState.Clear();
            return View("ListBrokers", brokersList.ToList());
        }
        // GET: DetailBroker | Méthode permettant d'afficher le détail d'un courtier
        public ActionResult DetailBroker(int? id)
        {
            broker SelectedBroker = db.brokers.Find(id); // requete de selection par l'id
            // si l'id est null ou non renseigné, ou que l'objet selectedbroker renvoyer vue erreur
            if (id == null || SelectedBroker == null)
            {
                return View("Error404");
            }
            return View("DetailBroker", SelectedBroker);
        }
        // POST: DetailBroker | Méthode permettant de modifier le courtier dans la bdd lors d'un POST
        [HttpPost]
        public ActionResult DetailBroker(broker broker)
        {
            using (db)
            {
                db.Entry(broker).State = EntityState.Modified; // UPDATE
                db.SaveChanges(); // Sauvegarde dans la bdd
                ViewBag.ModifySuccess = "Courtier modifié avec succès"; // Message de succes affiché dans la vue via la propriétée de ViewBag 
            }
            return RedirectToAction("DetailBroker/" + broker.idBroker);
        }
        // GET: DeleteBroker | Permet d'afficher la page de suppression d'un courtier
        [HttpGet]
        public ActionResult DeleteBroker(int? id)
        {
            // select query
            string selectOneBrokerQuery =   "SELECT [idBroker], [lastName], [firstName], [mail], [phoneNumber]" +
                                            "FROM [dbo].[brokers]" +
                                            "WHERE [idBroker] = " + id + ";";
            // si l'id est null, erreur404
            if (id == null)
            {
                return View("Error404");
            }
            // sinon, retourner la vue "confirmation de suppression" avec le broker sélectionné
            else
            {
                // execution de la query passé dans l'objet selectedBroker
                broker SelectedBroker = db.brokers.SqlQuery(selectOneBrokerQuery, id).SingleOrDefault();
                // si selectedBroker est null, erreur 404
                if (SelectedBroker == null)
                {
                    return View("Error404");
                }
                return View("DeleteBroker", SelectedBroker);
            }
        }
        // POST: DeleteBroker | Permet de supprimer un courtier de la bdd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteBroker(int? id, broker brokerToDelete)
        {
            // si l'id est null, erreur404
            // sinon, supprimer le broker ayant l'id sélectionné
            if (id == null)
            {
                return View("Error404");
            }
            else
            {
                // delete query
                string deleteBrokerQuery = "DELETE FROM [dbo].[brokers]" +
                                        "WHERE [idBroker] = " + id + ";";
                db.Database.ExecuteSqlCommand(deleteBrokerQuery); // execute la query
                return RedirectToAction("ListBrokers");
            }
        }
    }
}
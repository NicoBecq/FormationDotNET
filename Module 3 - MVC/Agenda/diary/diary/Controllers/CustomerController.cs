using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using diary.Models; // ajout du modèle
using PagedList;

namespace diary.Controllers
{
    public class CustomerController : Controller
    {
        private agendaEntities1 db = new agendaEntities1(); // nouvel objet db sur le modèles de la bdd
        // GET: Customer | Méthode permettant d'afficher la vue customer quand l'url le demande
        public ActionResult AddCustomer()
        {
            return View("Customer");
        }
        // POST: Customer | Méthode permettant d'insérer un client dans la bdd
        [HttpPost]
        [ValidateAntiForgeryToken] // permet d'éviter les injections de code dans le form
        public ActionResult AddCustomer(customer newCustomer)
        {
            using(db)
            {
                // si lastName ET firstName éxistent dans la base, afficher message d'erreur
                if ((db.customers.Any(x => x.lastName == newCustomer.lastName) && db.customers.Any(x => x.firstName == newCustomer.firstName)) || db.customers.Any(x => x.mail == newCustomer.mail))
                {
                    ViewBag.DuplicateMessage = "Le client que vous essayez d'ajouter est déjà enregistré";
                    return View("Customer");
                }
                // sinon INSERT INTO
                else
                {
                    // INSERT INTO
                    db.customers.Add(newCustomer); 
                    db.SaveChanges(); 
                    // Message de succès
                    ViewBag.SuccessMessage = "Nouveau client ajouté";
                }
            }
            ModelState.Clear(); // supprime les messages d'erreurs du model
            return View("Customer");
        }
        // GET: ListCustomer | Méthode permettant d'afficher la liste des clients
        public ActionResult ListCustomer(string searchString, int? page)
        {
            //select query
            var selectQuery = from m in db.customers
                              select m;
            // si searchString n'est pas null ou vide, set variable page à 1 et execute la query avec close WHERE
            if (!String.IsNullOrEmpty(searchString))
            {
                page = 1;
                selectQuery = selectQuery.Where(x => x.lastName.Contains(searchString) || x.firstName.Contains(searchString));
            }            
            int pageSize = 2; // nombre d'élements dans une page
            int pageNumber = (page ?? 1); // renvoye la valeur de la variable page si elle a une valeur, sinon renvoye 1 si page == null
            return View("ListCustomer", selectQuery.OrderBy(x => x.lastName).ToPagedList(pageNumber, pageSize));
        }
        // ProfilCustomer | Méthode permettant d'afficher le profil d'un client
        public async Task<ActionResult> ProfilCustomer(int id, customer Customer)
        {
            // select query par id
            string selectIdQuery = "SELECT [idCustomer], [lastName], [firstName], [mail], [phoneNumber], [budget]" +
                                    "FROM [dbo].[customers]" +
                                    "WHERE [idCustomer] = " + id + ";";
            // execution de la query et passage dans l'objet customer
            Customer = await db.customers.SqlQuery(selectIdQuery, id).SingleOrDefaultAsync();
            ModelState.Clear();
            return View("ProfilCustomer", Customer);
        }
        // POST: ProfilCustomer | Méthode permettant de modifier le client dans la bdd
        [HttpPost]
        public ActionResult ProfilCustomer(customer customer)
        {
            // upate query par id
            string updateQuery =    "UPDATE [dbo].[customers]" +
                                    "SET [lastName] = '" + customer.lastName + "'," +
                                    "[firstName] = '" + customer.firstName + "'," +
                                    "[mail] = '" + customer.mail + "'," +
                                    "[phoneNumber] = '" + customer.phoneNumber + "'," +
                                    "[budget] = '" + customer.budget + "'" +
                                    "WHERE [idCustomer] = " + customer.idCustomer + ";";
            db.Database.ExecuteSqlCommand(updateQuery); // execution de la query
            return RedirectToAction("ProfilCustomer/" + customer.idCustomer); // redirection sur la page profil
        }
        // GET: DeleteCustomer | Méthode permettant d'afficher la confirmation de suppression
        public async Task<ActionResult> DeleteCustomer(int? id)
        {
            // select query par id
            string selectOneCustomerQuery =     "SELECT [idCustomer], [lastName], [firstName], [mail], [phoneNumber], [budget]" +
                                                "FROM [dbo].[customers]" +
                                                "WHERE [idCustomer] = " + id + ";";
            // execution passage de la query dans l'objet selectedCustomer
            // si l'id ou l'objet selectedcustomer est null, erreur404
            if (id == null)
            {
                return View("Error404");
            }
            // sinon retourner la vue avec le selectedCustomer
            else
            {
                // execution de la query passé dans l'objet selectedCustomer
                customer selectedCustomer = await db.customers.SqlQuery(selectOneCustomerQuery, id).SingleOrDefaultAsync();
                // si selectedBroker est null, erreur 404
                if (selectedCustomer == null)
                {
                    return View("Error404");
                }
                return View("DeleteCustomer", selectedCustomer);
            }
        }
        // POST: DeleteCustomer | Méthode permettant de supprimer un client de la bdd
        [HttpPost]
        public ActionResult DeleteCustomer(int? id, customer customer)
        {
            // delete query
            string deleteQuery =    "DELETE FROM [dbo].[customers]" +
                                    "WHERE [idCustomer] = " + id + ";";

            //méthode linq
            //db.customers.Remove(db.customers.Find(id));
            //db.SaveChanges();

            // si l'id ou customer est null, erreur404
            if (id == null || customer == null)
            {
                return View("Error404");
            }
            // sinon execute la query
            else
            {
                db.Database.ExecuteSqlCommand(deleteQuery);
            }
            return RedirectToAction("ListCustomer"); // retour sur la liste des clients
        }
    }
}
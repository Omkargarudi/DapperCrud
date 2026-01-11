using DapperCrud.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DapperCrud.Models;



namespace DapperCrud.Controllers
{
    public class CustomerController : Controller
    {
        CustomerRepository rep = new CustomerRepository();
        // GET: Customer
        public ActionResult Index()
        {
            return View(rep.GetAll());
        }


        // Get Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            rep.Insert(customer);
            return RedirectToAction("Index");
        }
        // EDIT GET
        public ActionResult Edit(int id)
        {
            return View(rep.GetById(id));
        }

        // EDIT POST
        [HttpPost]
        public ActionResult Edit(Customer customer)
        {
            rep.Update(customer);
            return RedirectToAction("Index");
        }

        // DELETE GET
        public ActionResult Delete(int id)
        {
            return View(rep.GetById(id));
        }

        // DELETE POST
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            rep.Delete(id);
            return RedirectToAction("Index");
        }
    }
}


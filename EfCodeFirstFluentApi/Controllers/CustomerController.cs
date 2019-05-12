using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using EfCodeFirstFluentApi.Models.Manager;
using EfCodeFirstFluentApi.Models.Validators;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCodeFirstFluentApi.Controllers
{
    public class CustomerController : Controller
    {
        DatabaseContext databaseContext;
        BindingList<string> errors = new BindingList<string>();
        public CustomerController(DatabaseContext _databaseContext)
        {
            databaseContext = _databaseContext;
        }
        // GET: Customer
        public ActionResult Index()
        {
            return View(databaseContext.Customers.ToList());
        }

        // GET: Customer/Details/5
        public ActionResult Details(string id)
        {
            return View(databaseContext.Customers.Where(c => c.CustomerId == id).FirstOrDefault());
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Customer model)
        {
            //if (!ModelState.IsValid)//true dönerse attributes üzerinde tanımladığımız kısıtları,kontrolleri geçmiş demektir.
            //{ return View(collection); }
            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View(model);
            }
            try
            {
                Customer c = new Customer();
                c.CustomerId = Guid.NewGuid().ToString();
                c.FirstName = model.FirstName;
                c.SecondName = model.SecondName;
                c.UserName = model.UserName;
                c.Email = model.Email;
                c.Age = Convert.ToInt32(model.Age);
                c.City = model.City;
                c.Country = model.Country;

                databaseContext.Customers.Add(c);
                databaseContext.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index", "Customer");
            }
            catch
            {
                return View();
            }

        }

        // GET: Customer/Edit/5
        public ActionResult Edit(string id)
        {
            return View();
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
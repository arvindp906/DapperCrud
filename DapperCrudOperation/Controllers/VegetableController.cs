using DapperCrudOperation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperCrudOperation.Controllers
{
    public class VegetableController : Controller
    {
        private VegetableRepository veg = new VegetableRepository();
        // GET: Vegetable
        public ActionResult Index()
        {
            return View(veg.ViewAll());
        }

        // GET: Vegetable/Details/5
        public ActionResult Details(int id)
        {
            return View(veg.Get(id));
        }

        // GET: Vegetable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vegetable/Create
        [HttpPost]
        public ActionResult Create(Models.Vegetable vegetable)
        {
            if(ModelState.IsValid)
            {
                veg.Create(vegetable);
                return RedirectToAction("Index");
            }

            return View();
          
            
        }

        // GET: Vegetable/Edit/5
        public ActionResult Edit(int Id)
        {
            return View(veg.Get(Id));
        }

        // POST: Vegetable/Edit/5
        [HttpPost]
        public ActionResult Edit(Models.Vegetable vegetable)
        {
           
               if(ModelState.IsValid)
            {
                veg.Update(vegetable);
              return  RedirectToAction("Index");
            }

            return View();
            

        }

        // GET: Vegetable/Delete/5
        public ActionResult Delete(int id)
        {
            return View(veg.Get(id));
        }

        // POST: Vegetable/Delete/5
        [HttpPost]
        public ActionResult Delete(Models.Vegetable vegetable)
        {
           
                veg.Delete(vegetable.Id);
                return RedirectToAction("Index");

           
           

           
           
        }
    }
}

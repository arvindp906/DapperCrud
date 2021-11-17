using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VegetableCrud.Models;

namespace VegetableCrud.Controllers
{
    public class VegetablesController : Controller
    {
        private VegetablesRepository repository;

        public VegetablesController()
        {
            repository = new VegetablesRepository();
        }

        // GET: Vegetable
        public ActionResult Index(RequestModel request)
        {
            if (request.OrderBy == null)
            {
                request = new RequestModel
                {
                    Search = request.Search,
                    OrderBy = "name",
                    IsDescending = false
                };
            }
            ViewBag.Request = request;
            return View(repository.GetAll(request));
        }

        // GET: Vegetable/Details/5
        public ActionResult Details(int id)
        {
            return View(repository.Get(id));
        }

        // GET: Vegetable/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vegetable/Create
        [HttpPost]
        public ActionResult Create(Vegetable vegetable, bool editAfterSaving = false)
        {
            if(ModelState.IsValid)
            {
                var lastInsertedId = repository.Create(vegetable);
                if (lastInsertedId > 0)
                {
                    TempData["Message"] = "Record added successfully";
                } else
                {
                    TempData["Error"] = "Failed to add record";
                }
                if (editAfterSaving)
                {
                    return RedirectToAction("Edit", new { Id = lastInsertedId });
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        // GET: Vegetable/Edit/5
        public ActionResult Edit(int Id)
        {
            return View(repository.Get(Id));
        }

        // POST: Vegetable/Edit/5
        [HttpPost]
        public ActionResult Edit(Vegetable vegetable)
        {
            if (ModelState.IsValid)
            {
                var recordAffected = repository.Update(vegetable);
                if (recordAffected > 0)
                {
                    TempData["Message"] = "Record updated successfully";
                }
                else
                {
                    TempData["Error"] = "Failed to update record";
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: Vegetable/Delete/5
        public ActionResult Delete(int id)
        {
            return View(repository.Get(id));
        }

        // POST: Vegetable/Delete/5
        [HttpPost]
        public ActionResult Delete(Vegetable vegetable)
        {
            var recordAffected = repository.Delete(vegetable.Id);
            if (recordAffected > 0)
            {
                TempData["Message"] = "Record deleted successfully";
            }
            else
            {
                TempData["Error"] = "Failed to delete record";
            }
            return RedirectToAction("Index");
        }
    }
}

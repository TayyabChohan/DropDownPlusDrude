using Shahid_Bhai.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shahid_Bhai.Controllers
{
    public class HomeController : Controller
    {
        MondayDropEntities1 db = new MondayDropEntities1();

        public ActionResult Index()
        {
            var list = db.Employees.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult Create()
        {

            BindDropDownFOrCategory();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            BindDropDownFOrCategory();
            Employee emp =db.Employees.Find(id);
            return View(emp);
        }
        [HttpPost]
        public ActionResult Edit(Employee emp , int id)
        {
            Employee emp1=db.Employees.SingleOrDefault(m => m.EmpId == id);
            emp1.EmpId = emp.EmpId;
            emp1.Name = emp.Name;
            emp1.CNIC = emp.CNIC;
            emp1.Phone = emp.Phone;
            emp1.CategoryId = emp.CategoryId;
            emp1.ReligionId = emp.ReligionId;
            emp1.GendrId = emp.GendrId;
             db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {

            Employee emp = db.Employees.Find(id);
            if (emp == null)
            {
                HttpNotFound();
            }

            return View(emp);
        }
        public ActionResult Delete(int id)
        {

             Employee emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        private void BindDropDownFOrCategory()
        {
            var category = db.CategoryTbs.ToList();
            List<SelectListItem> catList = new SelectList(category, "CategoryId", "Title").ToList();
            ViewBag.CategoryBag = catList;

            var gender = db.GendrTbs.ToList();
            List<SelectListItem> GanderList = new SelectList(gender, "GendrId", "gType").ToList();
            ViewBag.genderBag = GanderList;

            var religion = db.Religions.ToList();
            List<SelectListItem> religionList = new SelectList(religion, "ReligionId", "name").ToList();
            ViewBag.ReligionBag = religionList;

        } 

    }
}
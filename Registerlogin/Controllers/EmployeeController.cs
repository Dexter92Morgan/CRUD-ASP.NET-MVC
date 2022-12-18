using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Registerlogin.Models;

namespace Registerlogin.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee


        //MVC_DBEntities db = new MVC_DBEntities();
        // Display List View
        [HttpGet]
        public ActionResult Index()
        {
            MVC_DBEntities db = new MVC_DBEntities();
            List<Employee> emplist = db.Employees.ToList();
            return View(emplist);
        }

        // Create Account
        [HttpGet]
        public ActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public ActionResult Create(Employee obj)
        {
            if(ModelState.IsValid)
            {
                MVC_DBEntities db = new MVC_DBEntities();
                db.Employees.Add(obj);
                db.SaveChanges();
                TempData["Message"] = "Data Insert Successfully";
            }
            ModelState.Clear();
            return View();
        }

        //// another code example

        //[HttpGet]
        //public ActionResult Edit(int id)
        //{
        //    MVC_DBEntities db = new MVC_DBEntities();
        //    var data = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
        //    return View(data);
        //}
        //[HttpPost]
        //public ActionResult Edit(Employee Model)
        //{
        //    MVC_DBEntities db = new MVC_DBEntities();
        //    var data = db.Employees.Where(x => x.EmployeeId == Model.EmployeeId).FirstOrDefault();
        //    if (data != null)
        //    {
        //        data.EmployeeId= Model.EmployeeId;
        //        data.Name = Model.Name;
        //        data.Gender= Model.Gender;
        //        data.City = Model.City;
        //        data.Salary = Model.Salary;
        //        db.SaveChanges();
        //    }

        //    return RedirectToAction("Index","Employee");
        //}

        // Editing
        [HttpGet]
        public ActionResult Edit(int id) // (string  id == null) for id is 0
        {
            MVC_DBEntities db = new MVC_DBEntities();
            Employee emp = db.Employees.Find(id);
            if(emp ==null) // for id is 0 or empty
            {
                return HttpNotFound(); 
            
            }
            else
            {
             
                return View(emp);

            }          
        }

        [HttpPost]

        public ActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                MVC_DBEntities db = new MVC_DBEntities();
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();

                return RedirectToAction("Index", "Employee");
            }
            else
            {


                return View(emp);
            }
        }

        //Details View
        public ActionResult Details(int id)
        {
            MVC_DBEntities db = new MVC_DBEntities();
            var data = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault();
            return View(data);
        }

        // Delete
        public ActionResult Delete(int id)
        {
            MVC_DBEntities db = new MVC_DBEntities();
            var data = db.Employees.Find(id);
            db.Employees.Remove(data);
            db.SaveChanges();
            ViewBag.Messsage = "Record Delete Successfully";
            return RedirectToAction("Index","Employee");
        }

    }
  
}
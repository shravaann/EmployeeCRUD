using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EmployeeCRUD.DAL;
using EmployeeCRUD.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Identity.Client;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCRUD.Controllers
{
    public class EmployeeFormsController : Controller
    {
        Employee_DAL _employeeDAL = new Employee_DAL();


        // GET: EmployeeFormController
        public ActionResult Index()
        {
            var EmployeeList = _employeeDAL.GetAll();
            return View(EmployeeList);
        }



        // GET: EmployeeFormController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeFormController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeForm model)
        {

            bool result = _employeeDAL.Insert(model);
            return RedirectToAction("Index");


        }

        // GET: EmployeeFormController/Details/5
        public ActionResult Details(int id)
        {
            EmployeeForm employee = _employeeDAL.GetById(id);
            return View(employee);
        }



        // GET: EmployeeFormController/Edit/5
        public ActionResult Edit(int id)
        {
            EmployeeForm employee = _employeeDAL.GetById(id);
            return View(employee);
        }

        // POST: EmployeeFormController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeForm model)
        {

            bool result = _employeeDAL.Update(model);
            return RedirectToAction("Index");


        }


        // GET: EmployeeFormController/Delete/5
        public ActionResult Delete(int id)
        {
            EmployeeForm employee = _employeeDAL.GetById(id);
            return View(employee);
        }

        // POST: EmployeeFormController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(EmployeeForm model)
        {

            bool result = _employeeDAL.Delete(model.Id);
            return RedirectToAction("Index");

        }

    }
}


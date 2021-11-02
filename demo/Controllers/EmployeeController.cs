using demo.BL.interfaces;
using demo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.Controllers
{
    public class EmployeeController:Controller
    {
        private IEmployee employeeRepo;  
        public EmployeeController(IEmployee employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var data = employeeRepo.getAllEmployees();

            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(EmployeeVM employeeVM)
        {
            if (ModelState.IsValid)
            {
                employeeRepo.AddEmployee(employeeVM);
                return RedirectToAction("Index", "Employee");
            }
            return View(employeeVM);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = employeeRepo.getById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM employeeVM)
        {
            try
            {
                if (ModelState.IsValid)
            {
                employeeRepo.EditEmployee(employeeVM);
                return RedirectToAction("Index", "Employee");
            }
        }
            catch (Exception ex)
            {
                var data = employeeRepo.getById(employeeVM.id);
                return View(data);
    }
            return View(employeeVM);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var data = employeeRepo.getById(id);
            return View(data);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult ConfirmDelete(int id)
        {
            try
            {
                employeeRepo.deleteEmployee(id);
                return RedirectToAction("Index", "Employee");
            }
            catch (Exception ex)
            {
                var data = employeeRepo.getById(id);
                return View(data);
            }
        }
    }
}

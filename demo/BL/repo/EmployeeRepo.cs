using demo.BL.interfaces;
using demo.DAL.dataBase;
using demo.DAL.entities;
using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace demo.BL.repo
{
    public class EmployeeRepo : IEmployee
    {
        private DemoContext db;
        public EmployeeRepo(DemoContext db)
        {
            this.db = db;
        }

        public IQueryable<EmployeeVM> getAllEmployees()
        {
            return db.employees.Select(a => 
            new EmployeeVM
            { 
                id = a.id,
                firstName = a.firstName,
                lastName = a.lastName,
                salary = a.salary 
            });
        }
        public EmployeeVM getById(int id)
        {
            return db.employees.Where(a => a.id == id).Select(a =>
            new EmployeeVM
            {
                id = a.id,
                firstName = a.firstName,
                lastName = a.lastName,
                salary = a.salary
            }).FirstOrDefault();
        }
        public  EmployeeVM AddEmployee(EmployeeVM employeeVm)
        {
            Employee employee = new Employee
            {
                id = employeeVm.id,
                firstName = employeeVm.firstName,
                lastName = employeeVm.lastName,
                salary = employeeVm.salary
            };
            db.Add(employee);
           int num= db.SaveChanges();
            if (num == 1)
            {
                return employeeVm;
            }
            else
                return null;
        }

    
        public int EditEmployee(EmployeeVM employeeVm)
        {
            Employee employee = new Employee
            {
                id = employeeVm.id,
                firstName = employeeVm.firstName,
                lastName = employeeVm.lastName,
                salary = employeeVm.salary
            };
            db.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            int result = db.SaveChanges();
            return result;
        }
        public int deleteEmployee(int id)
        {
            var DeletedObject = db.employees.Find(id);
            db.employees.Remove(DeletedObject);
            int result = db.SaveChanges();
            return result;
        }
    }
}

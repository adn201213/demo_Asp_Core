using demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace demo.BL.interfaces
{
    public interface IEmployee
    {

        public IQueryable<EmployeeVM> getAllEmployees();
        public EmployeeVM getById(int id);
        public EmployeeVM AddEmployee(EmployeeVM employeeVm);

        public int EditEmployee(EmployeeVM employeeVm);
        public int deleteEmployee(int id);

    }
}

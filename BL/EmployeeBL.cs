using System;
using System.Collections.Generic;
using DAL;
using Persistence;

namespace BL
{
    public class EmployeeBL
    {
        private EmployeeDAL employeeDAL;

        public EmployeeBL()
        {
            employeeDAL = new EmployeeDAL();
        }
        public Employee GetEmployeeById(int empId)
        {
            return employeeDAL.GetEmployeeById(empId);
        }    

        public List<Employee> GetEmployeesByDepartment(string dept_name)
        {
            return employeeDAL.GetEmployeesByDepartment(dept_name);
        }   
    }
}

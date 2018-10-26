using System;
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
    }
}

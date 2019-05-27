using System;
using System.Collections.Generic;
using BL;
using Persistence;

namespace PL_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // int empId;

            // Console.Write("Please enter an employee's id: ");
            // empId = Convert.ToInt32(Console.ReadLine());

            // EmployeeBL empBL = new EmployeeBL();

            // Employee emp =  empBL.GetEmployeeById(empId);

            // if(emp != null)
            // {
            //     Console.WriteLine("Employee ID: " + emp.EmployeeId);
            //     Console.WriteLine("First name: " + emp.EmployeeFirstName);
            //     Console.WriteLine("Last Name: " + emp.EmployeeLastName);
            // }

            string dept_name;

            Console.WriteLine("Nhap ten phong ban: ");
            dept_name = Console.ReadLine();

            EmployeeBL empBL = new EmployeeBL();

            List<Employee> listEmps = empBL.GetEmployeesByDepartment(dept_name);

            Console.WriteLine(listEmps[0].EmployeeId);
        }
    }
}

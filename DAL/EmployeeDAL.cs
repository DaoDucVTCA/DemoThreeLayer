using System;
using Persistence;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class EmployeeDAL
    {
        private string query;
        private MySqlDataReader reader;
        public Employee GetEmployeeById(int empID)
        {
            query = @"select emp_no, first_name, last_name
                    from Employees where emp_no=" + empID + ";";

            //Mở kết nối đến database
            DBHelper.OpenConnection();
            reader = DBHelper.ExecQuery(query);
            
            Employee employee = null;
            if(reader.Read())
            {
                employee = GetEmployeeInfo(reader);
            }

            DBHelper.CloseConnection();
            return employee;
        }
        private Employee GetEmployeeInfo(MySqlDataReader reader)
        {
            Employee emp = new Employee();
            emp.EmployeeId = reader.GetInt32("emp_no");
            emp.EmployeeFirstName = reader.GetString("first_name");
            emp.EmployeeLastName = reader.GetString("last_name");

            return emp;
        }
    }
}
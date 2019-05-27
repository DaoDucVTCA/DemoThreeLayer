using System;
using Persistence;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace DAL
{
    public class EmployeeDAL
    {
        private string query;
        private MySqlDataReader reader;
        private MySqlConnection connection;
        public EmployeeDAL()
        {
            connection = DBHelper.OpenConnection();
        }
        public Employee GetEmployeeById(int empID)
        {
            query = @"select emp_no, first_name, last_name
                    from Employees where emp_no=" + empID + ";";

            //Mở kết nối đến database
            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            
            Employee employee = null;
            if(reader.Read())
            {
                employee = GetEmployeeInfo(reader);
            }

            reader.Close();
            DBHelper.CloseConnection();
            return employee;
        }

        public List<Employee> GetEmployeesByDepartment(string dept_name)
        {
            if(connection.State == System.Data.ConnectionState.Closed){
                connection.Open();
            }

            query = @"select e.emp_no, e.first_name, e.last_name, de.dept_name 
                        from employees e inner join dept_emp d 
                        on e.emp_no = d.emp_no 
                        inner join departments de 
                        on de.dept_no = d.dept_no
                        where de.dept_name = " + "'" + dept_name + "'" + ";";

            MySqlCommand command = new MySqlCommand(query, connection);
            reader = command.ExecuteReader();
            List<Employee> listEmployees = new List<Employee>();

            if(reader != null)
            {
                listEmployees = GetListEmployees(command);
            }

            reader.Close();
            DBHelper.CloseConnection();
            return listEmployees;

        }
        private Employee GetEmployeeInfo(MySqlDataReader reader)
        {
            Employee emp = new Employee();
            emp.EmployeeId = reader.GetInt32("emp_no");
            emp.EmployeeFirstName = reader.GetString("first_name");
            emp.EmployeeLastName = reader.GetString("last_name");

            return emp;
        }
        private List<Employee> GetListEmployees(MySqlCommand command)
        {
            List<Employee> listEmployees = new List<Employee>();
            while(reader.Read())
            {
                listEmployees.Add(GetEmployeeInfo(reader));
            }
            Console.WriteLine(listEmployees.Count);
            connection.Close();
            return listEmployees;
        }
    }
}
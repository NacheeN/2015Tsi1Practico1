using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesMock : IDALEmployees
    {
        private List<Employee> employeesRepository = new List<Employee>()
        {
            new PartTimeEmployee(){HourlyDate = 100},
            new PartTimeEmployee(){HourlyDate = 150},
            new PartTimeEmployee(){HourlyDate = 200},
            new PartTimeEmployee(){HourlyDate = 250},
            new PartTimeEmployee(){HourlyDate = 300},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
            new FullTimeEmployee(){},
        };

        public void AddEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public void DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            return employeesRepository;
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public List<Employee> SearchEmployees(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}

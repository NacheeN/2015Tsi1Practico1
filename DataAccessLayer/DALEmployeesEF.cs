using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DALEmployeesEF : IDALEmployees
    {
        // agrego empleado
        public void AddEmployee(Employee emp)
        {

            throw new NotImplementedException();
        }


        // borro empleado
        public static void DeleteEmployee(int id)
        {
            EmployeeDBContext db = new
            EmployeeDBContext();

            var matched_Employee = (from c in db.GetTable<Employee>()
                                    where c.id == id
                                    select c).SingleOrDefault();

            try
            {
                db.Employee.DeleteOnSubmit(matched_Employee);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        public void UpdateEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
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

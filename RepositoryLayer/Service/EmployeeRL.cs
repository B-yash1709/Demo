using RepositoryLayer.Context;
using RepositoryLayer.EmployeeEntity;
using RepositoryLayer.Interface;

namespace RepositoryLayer.Service
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly EmployeeDbContext _dbContext;

        //  Constructor Injection for Database Context
        public EmployeeRL(EmployeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //  Add Employee
        public Employee AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges(); // Save changes to DB
            return employee;
        }

        // Update Employee
        public Employee UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee != null)
            {
                existingEmployee.Name = employee.Name;
                existingEmployee.Email = employee.Email;
                existingEmployee.Department = employee.Department;

                _dbContext.SaveChanges(); // Save changes to DB
                return existingEmployee;
            }
            return new Employee { }; // Return null if employee is not found
        }
    }
}

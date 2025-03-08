using BusinessLayer.Interface;
using RepositoryLayer.EmployeeEntity;
using RepositoryLayer.Interface;

namespace BusinessLayer.Service
{
    public class EmployeeBL : IEmployeeBL
    {
        private readonly IEmployeeRL _employeeRL;

        //  Constructor Injection for Repository Layer
        public EmployeeBL(IEmployeeRL employeeRL)
        {
            _employeeRL = employeeRL;
        }

        //  Add Employee
        public Employee AddEmployee(Employee employee)
        {
            return _employeeRL.AddEmployee(employee);
        }

        //  Update Employee
        public Employee UpdateEmployee(int id, Employee employee)
        {
            return _employeeRL.UpdateEmployee(id, employee);
        }
    }
}

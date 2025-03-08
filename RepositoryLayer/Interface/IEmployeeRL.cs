using RepositoryLayer.EmployeeEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmployeeRL
    {
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(int id, Employee employee);
       
    }
}




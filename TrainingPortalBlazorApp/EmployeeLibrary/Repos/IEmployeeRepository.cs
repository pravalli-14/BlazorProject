using EmployeeLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Repos
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(string empId, Employee employee);
        Task DeleteEmployeeAsync(string empId);
        Task<Employee> GetEmployeeByIdAsync(string empId);
        Task<List<Employee>> GetAllEmployeesAsync();
        Task<List<Employee>> GetEmployeesByDesignationAsync(string designation);

    }
}

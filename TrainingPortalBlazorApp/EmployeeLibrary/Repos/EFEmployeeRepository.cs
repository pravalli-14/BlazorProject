using EmployeeLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLibrary.Repos
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        ZelisEmployeeEFDBContext ctx;
        public EFEmployeeRepository()
        {
            ctx = new ZelisEmployeeEFDBContext();
        }
        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                await ctx.Employees.AddAsync(employee);
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex) { throw new EmployeeException(ex.Message); }
        }

        public async Task DeleteEmployeeAsync(string empId)
        {
            Employee emp = await GetEmployeeByIdAsync(empId);
            try
            {
                ctx.Employees.Remove(emp);
                await ctx.SaveChangesAsync();
            }
            catch (Exception e) { throw new EmployeeException("No Employee with the given ID"); }
        }

        public async Task<List<Employee>> GetAllEmployeesAsync()
        {
            List<Employee> employees = await ctx.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(string empId)
        {
            try
            {
                Employee employee = await (from e in ctx.Employees where e.EmpId == empId select e).FirstAsync();
                return employee;
            }
            catch (Exception ex)
            {
                throw new EmployeeException("No Employee with the given ID");
            }
        }

        public async Task<List<Employee>> GetEmployeesByDesignationAsync(string designation)
        {
            List<Employee> employees = await (from e in ctx.Employees where e.Designation == designation select e).ToListAsync();
            if (employees.Count == 0)
                throw new EmployeeException("No employee present with the given designation!!");
            else
                return employees;
        }
        public async Task UpdateEmployeeAsync(string empId, Employee employee)
        {
            try
            {
                Employee emp = await GetEmployeeByIdAsync(empId);
                emp.EmpName = employee.EmpName;
                emp.EmpPhoneNo = employee.EmpPhoneNo;
                emp.EmpEmail = employee.EmpEmail;
                emp.Designation = employee.Designation;
                await ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new EmployeeException("No such Employee Id");
            }
        }

    }
}

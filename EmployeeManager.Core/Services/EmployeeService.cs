using EmployeeManager.Core.Data;
using EmployeeManager.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManager.Core.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public List<Employee> FindByDepartment(string department)
        {
            return _dbContext.Employees.Where(e => e.Department == department).ToList();
        }

        public void UpdateEmployee(Employee employee)
        {
            _dbContext.Employees.Update(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            _dbContext.SaveChanges();
        }

        public bool RemoveEmployee(int id)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
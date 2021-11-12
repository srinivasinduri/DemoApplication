using DemoApp.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DemoApp.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(DbContext db,bool isMoc=false):base(db,isMoc)
        {

        }

        public List<Department> GetDepartments()
        {
            var re = context.Departments.Where(x => x.IsActive).ToList();
            return re;
        }

        public List<Employee> GetEmployees()
        {
            return ds.Where(x => x.IsActive).Select(e => new Employee
            {
                PkEmpId = e.PkEmpId,
                Name = e.Name,
                FkDeptId = e.FkDeptId,
                Designation = e.Designation,
                IsActive = e.IsActive
            }).ToList();
        }
        
    }
}

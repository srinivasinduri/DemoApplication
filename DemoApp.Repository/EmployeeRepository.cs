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
            
            var re = context.Departments.Select(x => new Department
            {
                Name = x.Name,
                IsActive = x.IsActive
            }).ToList();
            return re;
        }

        public List<DepartmentVM> GetDepartmentsWithName()
        {
            var alldepts = context.Departments.ToList().GroupBy(x => x.Name).
                Select(y=>new DepartmentVM
                { 
                    PkDeptid=y.First().PkDeptId,
                    Name=y.First().Name,
                    count=y.Count()
                }).ToList();
            return alldepts;
            //return context.Departments.ToList().GroupBy(d => d.Name).Select(x => new Department
            //{
            //    Name = x.First().Name
            //}).ToList();
        }

        public List<Employee> GetEmployees()
        {
            
            return ds.Select(e => new Employee
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

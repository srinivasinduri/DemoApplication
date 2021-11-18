using DemoApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoApp.Repository
{
    public interface IEmployeeRepository
    {
        List<Employee> GetEmployees();
        List<Department> GetDepartments();
        List<DepartmentVM> GetDepartmentsWithName();
    }
}

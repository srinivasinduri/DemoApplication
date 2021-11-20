using DemoApp.Model;
using DemoApp.Repository;
using DemoWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Controllers
{
    public class EmployeeController : Controller
    {
        readonly IEmployeeRepository _repository;
        readonly MyDemoDbContext _context;
        public EmployeeController(IEmployeeRepository rep, MyDemoDbContext context)
        {
            this._context = context;
            this._repository = rep;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {

            var res = _repository.GetEmployees();
            if(Helper.GetCurrentRole(User)==Roles.User.ToString())
            {
               var userres= res.Where(x => x.IsActive == true);
                return View(userres);
            }
            else
            {
            return View(res);
            }
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details()
        {
            //ViewBag.DeptCount =new SelectList(_repository.GetDepartmentsWithName(), "Name", "count").ToList();
            var list = _repository.GetDepartmentsWithName();
            return View(list);
        }
        [Authorize(Roles ="Admin")]
        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.Departments = new SelectList(_repository.GetDepartmentsWithName(), "PkDeptid", "Name");
            ViewBag.EmpNames= new SelectList(_repository.GetEmployees(), "FkDeptId", "Name");
            return View();
        }
        [Authorize(Roles = "Admin")]
        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee,int deptid)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    employee.FkDeptId = deptid;
                    _context.Add(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = _context.Employees.Find(id);
            ViewBag.Departments = new SelectList(_repository.GetDepartmentsWithName(), "PkDeptid", "Name",employee.FkDeptId);
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee,int fkdeptid)
        {
            if (id != employee.PkEmpId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                try
                {
                    var emp = _context.Employees.AsNoTracking().FirstOrDefault(x => x.PkEmpId == employee.PkEmpId);
                    emp.Name = employee.Name;
                    emp.Designation = employee.Designation;
                    emp.IsActive = employee.IsActive;
                    emp.FkDeptId = fkdeptid;
                    _context.Update(emp);
                    _context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.PkEmpId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    return View();
                }
                return RedirectToAction(nameof(Index));

            }
            return View(employee);
        }
        [Authorize(Roles = "Admin")]
        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var emp = _context.Employees.FirstOrDefault(e=>e.PkEmpId==id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }
        [Authorize(Roles = "Admin")]
        // POST: EmployeeController/Delete/5
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            try
            {
                var employee = _context.Employees.Find(id);
                _context.Remove(employee);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.PkEmpId == id);
        }
    }
}

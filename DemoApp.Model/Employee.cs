using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp.Model
{
    public partial class Employee
    {
        
        [Key]
        public int PkEmpId { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public int FkDeptId { get; set; }
        public bool IsActive { get; set; }
        public Department Department { get; set; }
    }
}

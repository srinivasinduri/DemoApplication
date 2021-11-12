using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp.Model
{
    public class Department
    {
        [Key]
        public int PkDeptId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}

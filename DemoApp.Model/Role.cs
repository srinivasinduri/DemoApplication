using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp.Model
{
    public class Role
    {
        [Key]
        public int PkRoleId { get; set; }
        public string RoleName { get; set; }
        public ICollection<UserProfile> userProfiles { get; set; }
    }
}

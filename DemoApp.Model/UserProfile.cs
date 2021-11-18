using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DemoApp.Model
{
    public partial class UserProfile
    {
        [Key]
        public int PkUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public DateTime RegisteredDate { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string EmailId { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
        public int FkRoleId { get; set; }
    }
}

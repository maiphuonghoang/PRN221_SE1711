using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Role
    {
        public Role()
        {
            Usernames = new HashSet<Account>();
        }

        public int RoleId { get; set; }
        public string? RoleName { get; set; }

        public virtual ICollection<Account> Usernames { get; set; }
    }
}

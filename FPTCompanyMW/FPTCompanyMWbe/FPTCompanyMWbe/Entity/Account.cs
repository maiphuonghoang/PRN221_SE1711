using System;
using System.Collections.Generic;

namespace FPTCompanyMWbe.Models
{
    public partial class Account
    {
        public Account()
        {
            Roles = new HashSet<Role>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual Employee? Employee { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Entity
{
    public class User
    {
        public int Id { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; } 
        public string UserName { get; set; }

        public string Password { get; set; }






    }
}

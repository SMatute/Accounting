using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Entity
{
    public class Roles
    {
        public int RoleId { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        public IList<UsersRoles> UsuariosRoles { get; set; }
    }
}

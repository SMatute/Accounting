using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Domain.Entity
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Usuario { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;




    }
}

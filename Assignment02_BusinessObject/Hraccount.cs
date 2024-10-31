using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_BusinessObject
{
    public class Hraccount
    {
        public string Email { get; set; } = null!;

        public string? Password { get; set; }

        public string? FullName { get; set; }

        public int? MemberRole { get; set; }
    }
}

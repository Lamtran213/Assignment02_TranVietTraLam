using Assignment02_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Services
{
    public interface IHraccountServices
    {
        public Hraccount GetHraccountByEmail(string email);
    }
}

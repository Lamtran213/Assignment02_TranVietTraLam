using Assignment02_BusinessObject;
using Assignment02_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Repositories
{
    public class HraccountRepo : IHraccountRepo
    {

        public Hraccount GetHraccountByEmail(string email) => HraccountDAO.Instance.GetHraccountByEmail(email);

    }
}

using Assignment02_BusinessObject;
using Assignment02_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Services
{
    public class HraccountServices : IHraccountServices
    {
        private readonly IHraccountRepo _repo;
        public HraccountServices() {
            _repo = new HraccountRepo();
        }

        public Hraccount GetHraccountByEmail(string email)
        {
            return _repo.GetHraccountByEmail(email);
        }
    }
}

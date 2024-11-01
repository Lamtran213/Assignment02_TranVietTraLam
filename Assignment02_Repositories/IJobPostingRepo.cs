using Assignment02_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Repositories
{
    public interface IJobPostingRepo
    {
        public List<JobPosting> GetJobPostings();
        public JobPosting GetJobPostingByID(string id);
        public bool AddJobPosting(JobPosting jobPosting);
        public bool DeleteJobPosting(string id);
        public bool UpdateJobPosting(JobPosting jobPostingUpdated);
    }
}

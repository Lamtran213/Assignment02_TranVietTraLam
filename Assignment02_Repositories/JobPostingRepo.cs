using Assignment02_BusinessObject;
using Assignment02_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Repositories
{
    public class JobPostingRepo : IJobPostingRepo
    {
        public bool AddJobPosting(JobPosting jobPosting) => JobPostingDAO.Instance.AddJobPosting(jobPosting);

        public bool DeleteJobPosting(string id) => JobPostingDAO.Instance.DeleteJobPosting(id);

        public JobPosting GetJobPostingByID(string id) => JobPostingDAO.Instance.GetJobPostingByID(id);

        public List<JobPosting> GetJobPostings() => JobPostingDAO.Instance.GetJobPostings();

        public bool UpdateJobPosting(JobPosting jobPostingUpdated) => JobPostingDAO.Instance.UpdateJobPosting(jobPostingUpdated);
    }
}

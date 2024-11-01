using Assignment02_BusinessObject;
using Assignment02_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Services
{
    public class JobPostingServices : IJobPostingServices
    {
        private readonly IJobPostingRepo _repo;
        public JobPostingServices()
        {
            _repo = new JobPostingRepo();
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            return _repo.AddJobPosting(jobPosting);
        }

        public bool DeleteJobPosting(string id)
        {
            return _repo.DeleteJobPosting(id);
        }

        public JobPosting GetJobPostingByID(string id)
        {
            return _repo.GetJobPostingByID(id);
        }

        public List<JobPosting> GetJobPostings()
        {
            return _repo.GetJobPostings();
        }

        public bool UpdateJobPosting(JobPosting jobPostingUpdated)
        {
            return _repo.UpdateJobPosting(jobPostingUpdated);
        }
    }
}

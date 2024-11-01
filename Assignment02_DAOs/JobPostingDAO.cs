using Assignment02_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_DAOs
{
    public class JobPostingDAO
    {
        private List<JobPosting> jobPostingList;
        private static JobPostingDAO instance;
        private readonly string jobPostingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileData/JobPosting.txt");
        public static JobPostingDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new JobPostingDAO();
                }
                return instance;
            }
        }
        private JobPostingDAO()
        {
            jobPostingList = new List<JobPosting>();
            LoadDataFromFile();
        }
        private void LoadDataFromFile()
        {
            if (File.Exists(jobPostingPath))
            {
                var lines = File.ReadAllLines(jobPostingPath);
                foreach (var line in lines)
                {
                    var data = line.Split('\t');
                    if (data.Length >= 4)
                    {
                        var jobPosting = new JobPosting
                        {
                            PostingId = data[0],
                            JobPostingTitle = data[1],
                            Description = data[2],
                            PostedDate = DateTime.Parse(data[3]),
                        };
                        jobPostingList.Add(jobPosting);
                    }
                }
            }
            else
            {
                File.Create(jobPostingPath).Dispose();
                Console.WriteLine("Job posting file not found. A new file has been created.");
            }
        }
        private void SaveDataToFile()
        {
            var lines = jobPostingList.Select(a => $"{a.PostingId}\t{a.JobPostingTitle}\t{a.Description}\t{a.PostedDate}");
            File.WriteAllLines(jobPostingPath, lines);
        }

        public List<JobPosting> GetJobPostings()
        {
            return jobPostingList.ToList();
        }
        public JobPosting GetJobPostingByID(string id)
        {
            return jobPostingList.SingleOrDefault(c => c.PostingId == id);
        }
        public bool AddJobPosting(JobPosting jobPosting)
        {
            if (jobPosting != null)
            {
                jobPostingList.Add(jobPosting);
                SaveDataToFile();
                return true;
            }
            return false;
        }
        public bool DeleteJobPosting(string id)
        {
            var jobPostingID = GetJobPostingByID(id);
            if (jobPostingID != null)
            {
                jobPostingList.Remove(jobPostingID);
                SaveDataToFile();
                return true;
            }
            return false;
        }
        public bool UpdateJobPosting(JobPosting jobPostingUpdated)
        {
            var jobPosting = GetJobPostingByID(jobPostingUpdated.PostingId);
            if (jobPosting != null)
            {
                jobPosting.PostingId = jobPostingUpdated.PostingId;
                jobPosting.JobPostingTitle = jobPostingUpdated.JobPostingTitle;
                jobPosting.Description = jobPostingUpdated.Description;
                jobPosting.PostedDate = jobPostingUpdated.PostedDate;
                SaveDataToFile();
                return true;
            }
            return false;
        }
    }
}

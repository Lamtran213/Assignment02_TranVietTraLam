using Assignment02_BusinessObject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Assignment02_DAOs
{
    public class CandidateProfileDAO
    {
        private static CandidateProfileDAO instance;
        public List<CandidateProfile> list;
        public List<JobPosting> posting;
        private readonly string candidateProfilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileData/CandidateProfile.txt");
        private readonly string jobPostingPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "FileData/JobPosting.txt");

        public static CandidateProfileDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CandidateProfileDAO();
                }
                return instance;
            }
        }

        private CandidateProfileDAO()
        {
            list = new List<CandidateProfile>();
            posting = LoadDataJobPosting();
            LoadDataFromFile();
        }

        private List<JobPosting> LoadDataJobPosting()
        {
            var jobPosting = new List<JobPosting>();
            if (File.Exists(jobPostingPath))
            {
                var lines = File.ReadAllLines(jobPostingPath);
                foreach (var line in lines)
                {
                    var data = line.Split('\t');
                    if (data.Length >= 2)
                    {
                        var job = new JobPosting
                        {
                            PostingId = data[0],
                            JobPostingTitle = data[1],
                        };
                        jobPosting.Add(job);
                    }
                }
            }
            else
            {
                File.Create(jobPostingPath).Dispose();
                Console.WriteLine("Job posting file not found. A new file has been created.");
            }
            return jobPosting;
        }

        private void LoadDataFromFile()
        {
            if (File.Exists(candidateProfilePath))
            {
                var lines = File.ReadAllLines(candidateProfilePath);
                foreach (var line in lines)
                {
                    var data = line.Split('\t');
                    if (data.Length >= 6)
                    {
                        var candidateProfile = new CandidateProfile
                        {
                            CandidateId = data[0],
                            Fullname = data[1],
                            Birthday = DateTime.Parse(data[2]),
                            ProfileShortDescription = data[3],
                            ProfileUrl = data[4],
                            PostingId = data[5],
                        };
                        list.Add(candidateProfile);
                    }
                }
            }
            else
            {
                File.Create(candidateProfilePath).Dispose();
                Console.WriteLine("Candidate profile file not found. A new file has been created.");
            }
        }

        private void SaveDataToFile()
        {
            var lines = list.Select(a => $"{a.CandidateId}\t{a.Fullname}\t{a.Birthday:yyyy-MM-dd}\t{a.ProfileShortDescription}\t{a.ProfileUrl}\t{a.PostingId}");
            File.WriteAllLines(candidateProfilePath, lines);
        }

        // CRUD Methods
        // Create
        public bool AddCandidateProfile(CandidateProfile candidate)
        {
            if (candidate != null)
            {
                list.Add(candidate);
                SaveDataToFile();
                return true;
            }
            return false;
        }

        // Read
        public CandidateProfile GetCandidateById(string candidateId)
        {
            return list.SingleOrDefault(c => c.CandidateId == candidateId);
        }

        // Update
        public bool UpdateCandidateProfile(CandidateProfile updatedCandidate)
        {
            var candidate = GetCandidateById(updatedCandidate.CandidateId);
            if (candidate != null)
            {
                candidate.Fullname = updatedCandidate.Fullname;
                candidate.Birthday = updatedCandidate.Birthday;
                candidate.ProfileShortDescription = updatedCandidate.ProfileShortDescription;
                candidate.ProfileUrl = updatedCandidate.ProfileUrl;
                candidate.PostingId = updatedCandidate.PostingId;
                SaveDataToFile();
                return true;
            }
            return false;
        }

        // Delete
        public bool DeleteCandidateProfile(string candidateId)
        {
            var candidate = GetCandidateById(candidateId);
            if (candidate != null)
            {
                list.Remove(candidate);
                SaveDataToFile();
                return true;
            }
            return false;
        }

        // Get All Candidates
        public List<CandidateProfile> GetAllCandidates()
        {
            List<CandidateProfile> candidates = new List<CandidateProfile>();
            foreach (CandidateProfile candidate in list)
            {
                var postingLoaded = posting?.SingleOrDefault(p => p.PostingId == candidate.PostingId);
                candidate.Posting = postingLoaded;

                if (posting == null)
                {
                    Console.WriteLine($"No JobPosting found for CandidateId: {candidate.CandidateId} with PostingId: {candidate.PostingId}");
                }

                candidates.Add(candidate);
            }
            return candidates;
        }
    }
}

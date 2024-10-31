using Assignment02_BusinessObject;
using Assignment02_DAOs;
using Assignment02_Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Services
{
    public class CandidateProfileServices : ICandidateProfileServices
    {
        private readonly ICandidateProfileRepo candidateProfileRepo;
        public CandidateProfileServices()
        {
            candidateProfileRepo = new CandidateProfileRepo();
        }
        public bool AddCandidateProfile(CandidateProfile candidate)
        {
            return candidateProfileRepo.AddCandidateProfile(candidate);
        }

        public bool DeleteCandidateProfile(string candidateId)
        {
            return candidateProfileRepo.DeleteCandidateProfile(candidateId);
        }

        public List<CandidateProfile> GetAllCandidates()
        {
            return candidateProfileRepo.GetAllCandidates();
        }

        public CandidateProfile GetCandidateById(string candidateId)
        {
            return candidateProfileRepo.GetCandidateById(candidateId);
        }

        public bool UpdateCandidateProfile(CandidateProfile updatedCandidate)
        {
            return candidateProfileRepo.UpdateCandidateProfile(updatedCandidate);
        }
    }
}

using Assignment02_BusinessObject;
using Assignment02_DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Repositories
{
    public class CandidateProfileRepo : ICandidateProfileRepo
    {
        public bool AddCandidateProfile(CandidateProfile candidate) => CandidateProfileDAO.Instance.AddCandidateProfile(candidate);

        public bool DeleteCandidateProfile(string candidateId) => CandidateProfileDAO.Instance.DeleteCandidateProfile(candidateId);

        public List<CandidateProfile> GetAllCandidates() => CandidateProfileDAO.Instance.GetAllCandidates();

        public CandidateProfile GetCandidateById(string candidateId) => CandidateProfileDAO.Instance.GetCandidateById(candidateId);

        public bool UpdateCandidateProfile(CandidateProfile updatedCandidate) => CandidateProfileDAO.Instance.UpdateCandidateProfile(updatedCandidate);
    }
}

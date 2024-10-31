using Assignment02_BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_Services
{
    public interface ICandidateProfileServices
    {
        public bool AddCandidateProfile(CandidateProfile candidate);
        public CandidateProfile GetCandidateById(string candidateId);
        public bool UpdateCandidateProfile(CandidateProfile updatedCandidate);
        public bool DeleteCandidateProfile(string candidateId);
        public List<CandidateProfile> GetAllCandidates();
    }
}

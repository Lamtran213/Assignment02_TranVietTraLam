using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment02_BusinessObject
{
    public class JobPosting
    {
        public string PostingId { get; set; } = null!;

        public string JobPostingTitle { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime? PostedDate { get; set; }

        public virtual ICollection<CandidateProfile> CandidateProfiles { get; set; } = new List<CandidateProfile>();
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUDCANDIDATOS.Models.ViewModels
{
    public class CandidateExVM
    {
        public Candidate Candidate { get; set; }
        public CadidateExperiences CandidateExperiences { get; set; }
    }
}

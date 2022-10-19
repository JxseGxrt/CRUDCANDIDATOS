using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDCANDIDATOS.Models
{
    [Table(name: "CadidateExperience")]
    public class CandidateExperience
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDCandidateExperience { get; set; }
        public string? Company { get; set; }
        public string? Job { get; set; }
        public string? Descripcion { get; set; }
        public double? Salary { get; set; }

        public DateTime? BeginDate { get; set; }

        public DateTime? EndDate { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public virtual Candidate? IDCandidate { get; set; }
    }
}

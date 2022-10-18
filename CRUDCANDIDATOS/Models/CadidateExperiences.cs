using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDCANDIDATOS.Models
{
    [Table(name: "CadidateExperience")]
    public class CadidateExperiences
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDCandidateExperience { get; set; }
        [StringLength(100)]
        public string? Company { get; set; }
        [StringLength(100)]
        public string? Job { get; set; }
        [StringLength(4000)]
        public string? Descripcion { get; set; }
        [MaxLength(10)]
        public double? Salary { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? BeginDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime InsertDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? ModifyDate { get; set; }

        public virtual Candidate? IDCandidate { get; set; }
    }
}

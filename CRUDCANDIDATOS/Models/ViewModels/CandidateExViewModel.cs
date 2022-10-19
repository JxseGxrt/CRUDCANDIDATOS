using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CRUDCANDIDATOS.Models.ViewModels
{
    public class CandidateExViewModel
    {
        public int IDCandidateExperience { get; set; }
        [StringLength(100)]
        public string? Company { get; set; }
        [StringLength(100)]
        public string? Job { get; set; }
        [StringLength(4000)]
        public string? Descripcion { get; set; }
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
        public int IdCandidate { get; set; }

    }
}

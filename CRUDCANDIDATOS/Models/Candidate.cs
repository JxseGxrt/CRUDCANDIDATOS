using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;


namespace CRUDCANDIDATOS.Models
{
    [Table(name: "Candidate")]
    public class Candidate
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int IDCandidate { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Email { get; set; }
        public DateTime InserDate { get; set; }
        public DateTime ModifyDate { get; set; }
        public virtual List<CandidateExperience>? Experience { get; set; }

    }
}

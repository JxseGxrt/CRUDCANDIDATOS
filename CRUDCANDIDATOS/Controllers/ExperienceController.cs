using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCANDIDATOS.DAL;
using CRUDCANDIDATOS.Models;
using CRUDCANDIDATOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing.Matching;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CRUDCANDIDATOS.Migrations;
using System.Runtime.ConstrainedExecution;

namespace CRUDCANDIDATOS.Controllers
{
    public class ExperienceController : Controller
    {
        private readonly CandidatesDbContext _DBContext;
        public ExperienceController(CandidatesDbContext context)
        {
            _DBContext = context;
        }
        
        [HttpGet]
        public IActionResult Experience_Query(int idCandidateEx, int idCandidate)
        {
            CandidateExperience CandidateExperience = new CandidateExperience();

            CandidateExperience = _DBContext.CandidateExperiences.Include(x => x.IDCandidate).Where(c => c.IDCandidateExperience == idCandidateEx).FirstOrDefault();

            CandidateExViewModel candidateEx = new CandidateExViewModel()
            {
                IdCandidate = idCandidate
            };

            if (CandidateExperience != null)
            {
                candidateEx = new CandidateExViewModel()
                {
                    IDCandidateExperience = CandidateExperience.IDCandidateExperience,
                    Company = CandidateExperience.Company,
                    Job = CandidateExperience.Job,
                    Descripcion = CandidateExperience.Descripcion,
                    Salary = CandidateExperience.Salary,
                    BeginDate = CandidateExperience.BeginDate,
                    EndDate = CandidateExperience.EndDate,
                    InsertDate = CandidateExperience.InsertDate,
                    ModifyDate = CandidateExperience.ModifyDate,
                    IdCandidate = idCandidate
                };
            }

            return View(candidateEx);
        }

        [HttpGet]
        public IActionResult Experience_Detail(int idCandidateEx, int idCandidate)
        {
            CandidateExperience CandidateExperience = new CandidateExperience();

            CandidateExperience = _DBContext.CandidateExperiences.Include(x => x.IDCandidate).Where(c => c.IDCandidateExperience == idCandidateEx).FirstOrDefault();

            CandidateExViewModel candidateEx = new CandidateExViewModel()
            {
                IdCandidate = idCandidate
            };

            if (CandidateExperience != null)
            {
                 candidateEx = new CandidateExViewModel()
                {
                    IDCandidateExperience = CandidateExperience.IDCandidateExperience,
                    Company = CandidateExperience.Company,
                    Job = CandidateExperience.Job,
                    Descripcion = CandidateExperience.Descripcion,
                    Salary = CandidateExperience.Salary,
                    BeginDate = CandidateExperience.BeginDate,
                    EndDate = CandidateExperience.EndDate,
                    InsertDate =  CandidateExperience.InsertDate,
                    ModifyDate = CandidateExperience.ModifyDate,
                    IdCandidate =  idCandidate
                };
            }    

            return View(candidateEx);
        }


        [HttpPost]
        public IActionResult Experience_Detail(CandidateExViewModel candidateExVM)
        {
            CandidateExperience CandidateExperience = new CandidateExperience();

            CandidateExperience.IDCandidateExperience = candidateExVM.IDCandidateExperience;
            CandidateExperience.Company = candidateExVM.Company;
            CandidateExperience.Job = candidateExVM.Job;
            CandidateExperience.Descripcion = candidateExVM.Descripcion;
            CandidateExperience.Salary = candidateExVM.Salary;
            CandidateExperience.BeginDate = candidateExVM.BeginDate;
            CandidateExperience.EndDate = candidateExVM.EndDate;
            CandidateExperience.IDCandidate = _DBContext.Candidate.Find(candidateExVM.IdCandidate);
            
            if (CandidateExperience.IDCandidateExperience == 0)
            {
                CandidateExperience.InsertDate = DateTime.Now;
                CandidateExperience.ModifyDate = DateTime.Now;
                _DBContext.CandidateExperiences.Add(CandidateExperience);
            }
            else
            {
                CandidateExperience.InsertDate = candidateExVM.InsertDate;
                CandidateExperience.ModifyDate = DateTime.Now;
                _DBContext.CandidateExperiences.Update(CandidateExperience);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Candidate_Detail", "Candidate", new { idCandidate = candidateExVM.IdCandidate });
        }


        [HttpGet]
        public IActionResult Experience_Delete(int idCandidateEx, int idCandidate)
        {
            CandidateExperience CandidateExperience = new CandidateExperience();

            CandidateExperience = _DBContext.CandidateExperiences.Include(x => x.IDCandidate).Where(c => c.IDCandidateExperience == idCandidateEx).FirstOrDefault();

            CandidateExViewModel candidateEx = new CandidateExViewModel()
            {
                IdCandidate = idCandidate
            };

            if (CandidateExperience != null)
            {
                candidateEx = new CandidateExViewModel()
                {
                    IDCandidateExperience = CandidateExperience.IDCandidateExperience,
                    Company = CandidateExperience.Company,
                    Job = CandidateExperience.Job,
                    Descripcion = CandidateExperience.Descripcion,
                    Salary = CandidateExperience.Salary,
                    BeginDate = CandidateExperience.BeginDate,
                    EndDate = CandidateExperience.EndDate,
                    InsertDate = CandidateExperience.InsertDate,
                    ModifyDate = CandidateExperience.ModifyDate,
                    IdCandidate = idCandidate
                };
            }

            return View(candidateEx);
        }

        [HttpPost]
        public IActionResult Experience_Delete(CandidateExViewModel candidateExVM)
        {
            CandidateExperience CandidateExperience = new CandidateExperience();
            CandidateExperience.IDCandidateExperience = candidateExVM.IDCandidateExperience;
            CandidateExperience.IDCandidate = _DBContext.Candidate.Find(candidateExVM.IdCandidate);

            _DBContext.CandidateExperiences.Remove(CandidateExperience);

            _DBContext.SaveChanges();

            return RedirectToAction("Candidate_Detail", "Candidate", new { idCandidate = candidateExVM.IdCandidate });
        }
    }
}

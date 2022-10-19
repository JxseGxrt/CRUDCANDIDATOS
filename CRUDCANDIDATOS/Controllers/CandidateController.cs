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
using System.Xml.Linq;

namespace CRUDCANDIDATOS.Controllers
{
    public class CandidateController : Controller
    {
        private readonly CandidatesDbContext _DBContext;
        public CandidateController(CandidatesDbContext context)
        {
            _DBContext = context;
        }

        [HttpGet]
        public IActionResult Candidate_Query(int idCandidate)
        {
            Candidate Candidate = new Candidate();

            if (idCandidate != 0)
            {
                Candidate = _DBContext.Candidate.Find(idCandidate);

            }

            CandidateViewModel candidateVM = new CandidateViewModel()
            {
                IDCandidate = Candidate.IDCandidate,
                Name = Candidate.Name,
                Surname = Candidate.Surname,
                Birthdate = Candidate.Birthdate,
                Email = Candidate.Email,
                InserDate = Candidate.InserDate,
                ModifyDate = Candidate.ModifyDate,
            };

            List<CandidateExperience> ListaExperiencia = _DBContext.CandidateExperiences.Where(ct => ct.IDCandidate.IDCandidate == idCandidate).ToList();

            candidateVM.Experience = new List<CandidateExperience>();
            candidateVM.Experience.AddRange(ListaExperiencia);

            return View(candidateVM);
        }


        [HttpGet]
        public IActionResult Candidate_Detail(int idCandidate)
        {
            Candidate Candidate = new Candidate();

            if (idCandidate != 0)
            {
                 Candidate = _DBContext.Candidate.Find(idCandidate);

            }

            CandidateViewModel candidateVM = new CandidateViewModel()
            {
                IDCandidate = Candidate.IDCandidate,
                Name = Candidate.Name,
                Surname = Candidate.Surname,
                Birthdate = Candidate.Birthdate,
                Email = Candidate.Email,
                InserDate = Candidate.InserDate,
                ModifyDate = Candidate.ModifyDate,
            };

            List<CandidateExperience> ListaExperiencia = _DBContext.CandidateExperiences.Where(ct => ct.IDCandidate.IDCandidate == idCandidate).ToList();

            candidateVM.Experience = new List<CandidateExperience>();
            candidateVM.Experience.AddRange(ListaExperiencia);        

            return View(candidateVM);
        }


        [HttpPost]
        public IActionResult Candidate_Detail(CandidateViewModel candidateViewModel)
        {

            Candidate Candidate = new Candidate();

            Candidate.IDCandidate = candidateViewModel.IDCandidate;
            Candidate.Name = candidateViewModel.Name;
            Candidate.Surname = candidateViewModel.Surname;
            Candidate.Birthdate = candidateViewModel.Birthdate;
            Candidate.Email = candidateViewModel.Email;
            Candidate.InserDate = candidateViewModel.InserDate;
            Candidate.ModifyDate = candidateViewModel.ModifyDate;

            if (candidateViewModel.IDCandidate == 0)
            {
                Candidate.InserDate = DateTime.Now;
                _DBContext.Candidate.Add(Candidate);
            }
            else
            {
                Candidate.ModifyDate = DateTime.Now;
                _DBContext.Candidate.Update(Candidate);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Candidate_Delete(int idCandidate)
        {
            Candidate candidate = _DBContext.Candidate.Include(ex => ex.Experience).Where(c => c.IDCandidate == idCandidate).FirstOrDefault();
            candidate = _DBContext.Candidate.Find(idCandidate);

            return View(candidate);
        }

        [HttpPost]
        public IActionResult Candidate_Delete(Candidate candidate)
        {

            List<CandidateExperience> ListaExperiencia = _DBContext.CandidateExperiences.Where(ct => ct.IDCandidate.IDCandidate == candidate.IDCandidate).ToList();

  
            foreach (var item in ListaExperiencia)
            {
                CandidateExperience ce = _DBContext.CandidateExperiences.Find(item.IDCandidateExperience);
                _DBContext.CandidateExperiences.Remove(ce);
            }

            _DBContext.Candidate.Remove(candidate);

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
  
    }
}

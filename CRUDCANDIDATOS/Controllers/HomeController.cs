using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDCANDIDATOS.DAL;
using CRUDCANDIDATOS.Models;
using CRUDCANDIDATOS.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Routing.Matching;
using System.Collections.Generic;

namespace CRUDCANDIDATOS.Controllers
{
    public class HomeController : Controller
    {
        private readonly CandidatosDbContext _DBContext;

        public HomeController(CandidatosDbContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Candidate> Candidatos = _DBContext.Candidate.Include(e => e.Experience).ToList();

            return View(Candidatos);
        }

        [HttpGet]
        public IActionResult Candidato_Detalle(int idCandidato)
        {
            CandidateVM candidateVM = new CandidateVM()
            {
                Candidate = new Candidate(),
                //ListaExperiencia = _DBContext.CandidateExperiences.Select(ex => new CadidateExperiences()
                //{
                //    IDCandidate = ex.IDCandidate,
                //    Value = ex.IDCandidateExperience.ToString()
                //}).ToList()
            };

            List<CadidateExperiences> ListaExperiencia = _DBContext.CandidateExperiences.Where(ct => ct.IDCandidate.IDCandidate == idCandidato).ToList();
           
            candidateVM.Candidate.Experience = new List<CadidateExperiences>();
            candidateVM.Candidate.Experience.AddRange(ListaExperiencia);

            if (idCandidato!= 0)
            {
                candidateVM.Candidate = _DBContext.Candidate.Find(idCandidato);

            }

            return View(candidateVM);
        }


        [HttpPost]
        public IActionResult Candidato_Detalle(CandidateVM candidateVM)
        {           

            if (candidateVM.Candidate.IDCandidate == 0)
            {
                candidateVM.Candidate.InserDate = DateTime.Now;
                _DBContext.Candidate.Add(candidateVM.Candidate);
            }
            else
            {
                candidateVM.Candidate.ModifyDate = DateTime.Now;
                _DBContext.Candidate.Update(candidateVM.Candidate);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Eliminar(int idCandidato)
        {
            Candidate candidate = _DBContext.Candidate.Include(ex => ex.Experience).Where(c => c.IDCandidate == idCandidato).FirstOrDefault();
            candidate = _DBContext.Candidate.Find(idCandidato);


            return View(candidate);
        }

        [HttpPost]
        public IActionResult Eliminar(Candidate candidate)
        {

            foreach (var item in candidate.Experience)
            {
                CadidateExperiences ce = _DBContext.CandidateExperiences.Find(item.IDCandidateExperience);
                _DBContext.CandidateExperiences.Remove(ce);
            }

            _DBContext.Candidate.Remove(candidate);     

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Experiencia_Detalle(int idCandidatoEx)
        {
            CandidateExVM candidateEx = new CandidateExVM()
            {
                CandidateExperiences = new CadidateExperiences(),
                Candidate = new Candidate()
            };

            if (idCandidatoEx != 0)
            {
                candidateEx.CandidateExperiences = _DBContext.CandidateExperiences.Include(x => x.IDCandidate).Where(c => c.IDCandidateExperience == idCandidatoEx).FirstOrDefault();
                candidateEx.Candidate = _DBContext.Candidate.Find(candidateEx.CandidateExperiences.IDCandidate.IDCandidate);
            }
            else
            {
                candidateEx.CandidateExperiences.IDCandidate = candidateEx.Candidate;
            }

            return View(candidateEx);
        }


        [HttpPost]
        public IActionResult Experiencia_Detalle(CandidateExVM candidateExVM)
        {
     

            if (candidateExVM.CandidateExperiences.IDCandidateExperience == 0)
            {
                CadidateExperiences CandidateExperiences = _DBContext.CandidateExperiences.Include(x => x.IDCandidate).Where(c => c.IDCandidateExperience == candidateExVM.CandidateExperiences.IDCandidateExperience).FirstOrDefault();
                candidateExVM.CandidateExperiences.IDCandidate = _DBContext.Candidate.Find(CandidateExperiences.IDCandidate.IDCandidate);
                candidateExVM.CandidateExperiences.InsertDate = DateTime.Now;
                candidateExVM.CandidateExperiences.ModifyDate = DateTime.Now;
                _DBContext.CandidateExperiences.Add(candidateExVM.CandidateExperiences);
            }
            else
            {
                
                candidateExVM.CandidateExperiences.InsertDate = _DBContext.Candidate.Find(candidateExVM.Candidate.IDCandidate).InserDate;
                candidateExVM.CandidateExperiences.ModifyDate = DateTime.Now;
                _DBContext.CandidateExperiences.Update(candidateExVM.CandidateExperiences);
            }

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult EliminarExperiencia(int idCandidatoEx)
        {
            CadidateExperiences cex = _DBContext.CandidateExperiences.Where(c => c.IDCandidateExperience == idCandidatoEx).FirstOrDefault();
            cex = _DBContext.CandidateExperiences.Find(idCandidatoEx);

            return View(cex);
        }

        [HttpPost]
        public IActionResult EliminarExperiencia(CadidateExperiences Experiencia)
        {
            _DBContext.CandidateExperiences.Remove(Experiencia);

            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
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
        private readonly CandidatesDbContext _DBContext;

        public HomeController(CandidatesDbContext context)
        {
            _DBContext = context;
        }

        public IActionResult Index()
        {
            List<Candidate> Candidatos = _DBContext.Candidate.Include(e => e.Experience).ToList();

            return View(Candidatos);
        }     

    }
}
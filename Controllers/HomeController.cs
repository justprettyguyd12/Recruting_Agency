using Microsoft.AspNetCore.Mvc;
using Recruting_Agency_POP.Data.Interfaces;
using Recruting_Agency_POP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllResumes _resumeRep;
        private readonly IAllVacancies _vacanciesRep;

        public HomeController(IAllResumes resumeRep, IAllVacancies vacanciesRep)
        {
            _resumeRep = resumeRep;
            _vacanciesRep = vacanciesRep;
        }

        public ViewResult Index()
        {
            var home = new HomeViewModel
            {
                AllResumes = _resumeRep.AllResumes,
                AllVacancies = _vacanciesRep.AllVacancies
            };
            return View(home);
        }

    }
}

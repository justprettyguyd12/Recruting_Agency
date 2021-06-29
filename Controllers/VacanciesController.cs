using Microsoft.AspNetCore.Mvc;
using Recruting_Agency_POP.Data.Interfaces;
using Recruting_Agency_POP.Data.Models;
using Recruting_Agency_POP.ViewModels;

namespace Recruting_Agency_POP.Controllers
{
    public class VacanciesController : Controller
    {
        private readonly IAllVacancies _allVacancies;

        public VacanciesController(IAllVacancies iAllVacancies)
        {
            _allVacancies = iAllVacancies;
        }

        public ViewResult ListVacancies()
        {
            ViewBag.Title = "Все вакансии";
            VacanciesListViewObject obj = new VacanciesListViewObject();
            obj.AllVacancies = _allVacancies.AllVacancies;
            return View(obj);
        }

        public ViewResult VacancyID(int id)
        {
            ViewBag.Title = "Просмотр резюме";
            VacancyViewObject obj = new VacancyViewObject
            {
                ObjectVacancy = _allVacancies.getObjectVacancy(id)
            };
            return View(obj);
        }

        public IActionResult AddVacancy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddVacancy(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                _allVacancies.AddNewVacancy(vacancy);
                return RedirectToAction("Complete");
            }

            return View(vacancy);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Вакансия добавлена";
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Recruting_Agency_POP.Data.Interfaces;
using Recruting_Agency_POP.Data.Models;
using Recruting_Agency_POP.ViewModels;

namespace Recruting_Agency_POP.Controllers
{
    public class ResumesController : Controller
    {
        private readonly IAllResumes _allResumes;

        public ResumesController (IAllResumes iAllResumes)
        {
            _allResumes = iAllResumes;
        }

        public ViewResult ListResumes()
        {
            ViewBag.Title = "Все резюме";
            ResumesListViewObject obj = new ResumesListViewObject
            {
                AllResumes = _allResumes.AllResumes,
                isSelected = "Все резюме"
            };
            return View(obj);
        }

        [HttpPost]
        public ViewResult ListResumes(string isSelected)
        {
            ViewBag.Title = "Все резюме";
            ResumesListViewObject obj = new ResumesListViewObject
            {
                AllResumes = _allResumes.AllResumes,
                isSelected = isSelected
            };
            return View(obj);
        }

        public ViewResult ResumeID(int id)
        {
            ViewBag.Title = "Просмотр резюме";
            ResumeViewObject obj = new ResumeViewObject
            {
                ObjectResume = _allResumes.getObjectResume(id)
            };
            return View(obj);
        }

        public IActionResult AddResume()
        { 
            return View();
        }

        [HttpPost]
        public IActionResult AddResume(Resume resume)
        {
            if (ModelState.IsValid)
            {
                _allResumes.AddNewResume(resume);
                return RedirectToAction("Complete");
            }
            return View(resume);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Резюме добавлено";
            return View();
        }

        [HttpPost]
        public IActionResult ChangeIsSelected(int id)
        {
            ResumeViewObject resume = new ResumeViewObject
            {
                ObjectResume = _allResumes.getObjectResume(id)
            };
            resume.ObjectResume.IsSelected = !resume.ObjectResume.IsSelected; //swap IsSelected:)
            _allResumes.ChangeIsSelected(resume.ObjectResume);

            return RedirectToAction("ResumeID", new { id = resume.ObjectResume.id});
        }
    }
}

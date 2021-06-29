using Microsoft.EntityFrameworkCore;
using Recruting_Agency_POP.Data.Interfaces;
using Recruting_Agency_POP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data.Repository
{
    public class ResumeRepository : IAllResumes
    {
        private readonly AppDBContent appDBContent;

        public ResumeRepository (AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Resume> AllResumes => appDBContent.Resume;

        public IEnumerable<Resume> getSelectedResumes => appDBContent.Resume.Where(c => c.IsSelected);

        public Resume getObjectResume(int resumeID) => appDBContent.Resume.FirstOrDefault(p => p.id == resumeID);

        public void AddNewResume(Resume resume)
        {
            appDBContent.Resume.Add(resume);
            appDBContent.SaveChanges();
        }

        public void ChangeIsSelected(Resume resume)
        {
            var customer = appDBContent.Resume
                .Where(c => c.id == resume.id)
                .FirstOrDefault();

            // Внести изменения
            customer.IsSelected = resume.IsSelected;

            // Сохранить изменения
            appDBContent.SaveChanges();
        }
    }
}

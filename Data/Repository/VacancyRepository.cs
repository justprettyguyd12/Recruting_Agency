using Microsoft.EntityFrameworkCore;
using Recruting_Agency_POP.Data.Interfaces;
using Recruting_Agency_POP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data.Repository
{
    public class VacancyRepository : IAllVacancies
    {
        private readonly AppDBContent appDBContent;

        public VacancyRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Vacancy> AllVacancies => appDBContent.Vacancy;

        public IEnumerable<Vacancy> getSelectedVacancies => appDBContent.Vacancy.Where(c => c.IsSelected);

        public Vacancy getObjectVacancy(int vacancyID) => appDBContent.Vacancy.FirstOrDefault(p => p.id == vacancyID);

        public void AddNewVacancy(Vacancy vacancy)
        {
            appDBContent.Vacancy.Add(vacancy);
            appDBContent.SaveChanges();
        }
    }
}

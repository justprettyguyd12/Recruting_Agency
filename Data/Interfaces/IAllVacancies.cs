using Recruting_Agency_POP.Data.Models;
using System.Collections.Generic;


namespace Recruting_Agency_POP.Data.Interfaces
{
    public interface IAllVacancies
    {
        IEnumerable<Vacancy> AllVacancies { get; }

        IEnumerable<Vacancy> getSelectedVacancies { get; }

        Vacancy getObjectVacancy(int vacancyID);

        void AddNewVacancy(Vacancy vacancy);
    }
}

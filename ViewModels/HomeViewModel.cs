using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Recruting_Agency_POP.Data.Models;

namespace Recruting_Agency_POP.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Resume> AllResumes { get; set; }

        public IEnumerable<Vacancy> AllVacancies { get; set; }
    }
}

using Recruting_Agency_POP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.ViewModels
{
    public class ResumesListViewObject
    {
        public IEnumerable<Resume> AllResumes { get; set; }

        public String isSelected { get; set; }
    }
}

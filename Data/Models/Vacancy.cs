using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data.Models
{
    public class Vacancy
    {
        [BindNever]
        public int id { set; get; }

        [MinLength(5)]
        [Required(ErrorMessage = "Введите не менее 5 символов")]
        public String VacancyName { set; get; }

        [Required(ErrorMessage = "Введите корректное число")]
        public uint Salary { set; get; }

        [MinLength(5)]
        [Required(ErrorMessage = "Введите не менее 5 символов")]
        public String Resp { set; get;} //обязанности

        [MinLength(5)]
        [Required(ErrorMessage = "Введите не менее 5 символов")]
        public String Requests { set; get; } //требования

        [MinLength(5)]
        [Required(ErrorMessage = "Введите не менее 5 символов")]
        public String City { set; get; }

        public bool IsSelected { set; get; }

        public String img { set; get; }

    }
}

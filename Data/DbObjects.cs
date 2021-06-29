using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Recruting_Agency_POP.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data
{
    public class DbObjects
    {
        private static Dictionary<string, Resume> resume;
        private static Dictionary<string, Vacancy> vacancy;

        public static void Initial(AppDBContent content)
        {
            if (!content.Resume.Any())
                content.Resume.AddRange(Resumes.Select(content => content.Value));

            if (!content.Vacancy.Any())
            {
                content.Vacancy.AddRange(Vacancies.Select(content => content.Value));
            }

            content.SaveChanges();
        }

        public static Dictionary<string, Resume> Resumes
        {
            get
            {
                if (resume == null)
                {
                    var list = new Resume[]
                    {
                        new Resume
                        {
                            Post = "Верстальщик",
                            Name = "Василий",
                            Surname = "Пупкин",
                            Birthday = new DateTime(2000, 9, 17),
                            PhoneNumber = "88005553535",
                            Email = "example@mail.com",
                            Salary = 54000,
                            City = "Самара",
                            IsSelected = false, 
                            img = "~/img/resume_png.png"
                        },
                        new Resume
                        {
                            Post = "Frontend Developer",
                            Name = "Валерий",
                            Surname = "Жмышенко",
                            Birthday = new DateTime(2000, 9, 17),
                            PhoneNumber = "88005553535",
                            Email = "example@mail.com",
                            Salary = 80000,
                            City = "Москва",
                            IsSelected = true,
                            img = "~/img/resume_png.png"
                        }
                    };

                    resume = new Dictionary<string, Resume>();
                    foreach (Resume r in list)
                        resume.Add(r.Post, r);
                }

                return resume;
            }
        }

        public static Dictionary<string, Vacancy> Vacancies
        {
            get
            {
                if (vacancy == null)
                {
                    var list = new List<Vacancy>
                    {
                        new Vacancy
                        {
                            VacancyName = "Java junior developer",
                            Salary = 50000,
                            Resp = "Работать",
                            Requests = "Иметь прямые руки и извилистый мозг",
                            City = "Самара", 
                            IsSelected = false, 
                            img = "~/img/vacancy_png.png"
                        },
                        new Vacancy
                        {
                            VacancyName = "C# middle developer",
                            Salary = 100000,
                            Resp = "Работать",
                            Requests = "Иметь прямые руки и извилистый мозг",
                            City = "Москва", 
                            IsSelected = false,
                            img = "~/img/vacancy_png.png"
                        }
                    };

                    vacancy = new Dictionary<string, Vacancy>();
                    foreach (Vacancy v in list)
                        vacancy.Add(v.VacancyName, v);
                }

                return vacancy;
            }
        }
    }
}

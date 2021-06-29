using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Recruting_Agency_POP.Data.Models
{
    public class Resume
    {
        [BindNever]
        public int id { set; get; }

        [MinLength(5)]
        [Required(ErrorMessage = "Введите не менее 5 символов")]
        public String Post { set; get; }

        [MinLength(2)]
        [Required(ErrorMessage = "Введите не менее 2 символов")]
        public String Name { set; get; }

        [MinLength(2)]
        [Required(ErrorMessage = "Введите не менее 2 символов")]
        public String Surname { set; get; }

        [DataType(DataType.Date)]
        public DateTime Birthday { set; get; }

        [MinLength(10)]
        [Required(ErrorMessage = "Введите корректный номер телефона")]
        [MaxLength(12)]
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { set; get; }

        [MinLength(5)]
        [Required(ErrorMessage = "Введите корректный адрес почты")]
        [DataType(DataType.EmailAddress)]
        public String Email { set; get; }

        [Required(ErrorMessage = "Введите корректное число")]
        public uint Salary { set; get; }

        [MinLength(2)]
        [Required(ErrorMessage = "Введите не менее 2 символов")]
        public String City { set; get; }

        public bool IsSelected { set; get; }

        public String img { set; get; }
    }
}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Recruting_Agency_POP.Data.Models;

namespace Recruting_Agency_POP.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent (DbContextOptions<AppDBContent> options) : base(options)
        {

        }

        public DbSet<Resume> Resume { get; set; }

        public DbSet<Vacancy> Vacancy { get; set; }
    }
}

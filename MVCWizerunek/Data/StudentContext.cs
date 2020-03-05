using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCWizerunek.Models;

namespace MVCWizerunek.Data
{
    public class StudentContext: DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
            : base(options)
        {
        }

        public DbSet<Studenci> student{ get; set; }

    }
}

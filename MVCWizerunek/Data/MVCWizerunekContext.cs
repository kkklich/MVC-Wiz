using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MVCWizerunek.Models
{
    public class MVCWizerunekContext : DbContext
    {
        public MVCWizerunekContext (DbContextOptions<MVCWizerunekContext> options)
            : base(options)
        {
        }

        public DbSet<MVCWizerunek.Models.Studenci> Studenci { get; set; }
    }
}

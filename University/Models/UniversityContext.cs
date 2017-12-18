using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace University.Models
{
    public class UniversityContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Pulpit> Pulpits { get; set; }
        public DbSet<Specialty> Speciaties { get; set; }
        public DbSet<TypeOfDiscipline> TypeOfDisciplins { get; set; }
        public DbSet<Discipline> Disciplins { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }
    }
}

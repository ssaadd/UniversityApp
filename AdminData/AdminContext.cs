using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace University.AdminData
{
    public class AdminContext : DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public AdminContext(DbContextOptions<AdminContext> options)
            : base(options)
        {
        }
    }
}

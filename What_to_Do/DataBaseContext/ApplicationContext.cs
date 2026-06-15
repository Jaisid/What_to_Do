using Microsoft.EntityFrameworkCore;
using What_to_Do.Models;
using What_to_Do.Models.Entities;

namespace What_to_Do.DataBaseContext
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options) { }
       

        public virtual DbSet<City>Cities { get; set; }
        public virtual DbSet<User> Users { get; set; }

    }
}

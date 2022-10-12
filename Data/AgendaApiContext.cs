using AgendaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaAPI.Data
{
    public class AgendaApiContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            User ana = new User()
            {
                Id = 1,
                Name = "Ana",
                LastName = "Braconi",
                Password = "Pa$$word",
                Email = "anabraconi@gmail.com",
                UserName = "anita"
            };

            User cecilia = new User()
            {
                Id = 2,
                Name = "Cecilia",
                LastName = "Tosto",
                Password = "contraseñadificil",
                Email = "ceciliatorres@gmail.com",
                UserName = "ceciT"
            };

            Contact emilia = new Contact()
            {
                Id = 1,
                Name = "Emilia",
                CelularNumber = 3412347689,
                Description = "Amiga",
                TelephoneNumber = null,
                UserId = ana.Id,
            };

            Contact juan = new Contact()
            {
                Id = 2,
                Name = "Juan Cruz",
                CelularNumber = 3412347665,
                Description = "Hermano",
                TelephoneNumber = null,
                UserId = cecilia.Id,
            };

            Contact gustavo = new Contact()
            {
                Id = 3,
                Name = "Gustavo",
                CelularNumber = 3410847665,
                Description = "Papa",
                TelephoneNumber = null,
                UserId = ana.Id,
            };

            modelBuilder.Entity<Contact>().HasData(emilia, juan, gustavo);
            modelBuilder.Entity<User>().HasData(cecilia, ana);

            modelBuilder.Entity<User>().HasMany<Contact>(u => u.Contacts).WithOne(c => c.User);

            base.OnModelCreating(modelBuilder);
        }
    }
}

using CLIMFinders.Domain.Entities;
using Given.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace CLIMFinders.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Businesses> Businesses { get; set; }
        public virtual DbSet<Matches> Matches { get; set; }
        public virtual DbSet<Notifications> Notifications { get; set; }
        public virtual DbSet<Payments> Payments { get; set; }
        public virtual DbSet<Searches> Searches { get; set; }
        public virtual DbSet<SubscriptionPlans> SubscriptionPlans { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }      
        public virtual DbSet<Vehicles> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Roles>().HasData(
                new Roles { Id = 1, RoleNanme = "SuperAdmin" },
                new Roles { Id = 2, RoleNanme = "Users" },
                new Roles { Id = 3, RoleNanme = "Tow" },
                new Roles { Id = 4, RoleNanme = "Impound" }
            );

            modelBuilder.Entity<SubscriptionPlans>().HasData(
                new SubscriptionPlans { Id = 1, Tier = "Free Tier", Amount = 0 , Duration = 0},
                new SubscriptionPlans { Id = 2, Tier = "Paid Tier", Amount = 10 , Duration = 1  }
                );

            var hash = new List<byte[]>();
            string password = "0000";

            using (var hmac = new HMACSHA512())
            {
                var hashOne = hmac.Key;
                var hashTwo = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                hash.Add(hashOne);
                hash.Add(hashTwo);
            }

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Password = "MDAwMA==", Email="admin@admin.com", ConfirmedOn = DateTime.Now, FullName = "SuperAdmin", IsConfirmed = true,
                 PasswordHash = hash[0], PasswordSalt = hash[1] , RoleId = 1
                });
        }
    }
}

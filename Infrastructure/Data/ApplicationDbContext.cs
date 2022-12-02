using ApplicationCore.Models;
using Infrastructure.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Animal> Animal { get; set; }
        public DbSet<EventModel> EventModels { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventModel>().ToTable(nameof(EventModel))
                .HasMany(c => c.ApplicationUsers)
                .WithMany(i => i.EventModels);
            base.OnModelCreating(modelBuilder);

            //Seeding Roles to AspNetRoles table
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2c5e17e-3b0e-446f-86af-438d56fd7210",
                Name = SD.AdminRole,
                NormalizedName = SD.AdminRole.ToUpper()
            });
            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "2c5e17e-3b0e-446f-86af-438d56fd7211",
                Name = SD.CustomerRole,
                NormalizedName = SD.CustomerRole.ToUpper()
            });
         

            //a hasher to hass the password before  seeding the user
            var hasher = new PasswordHasher<ApplicationUser>();

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d047cdb9",
                    UserName = "Admin@Admin.com",
                    Email = "Admin@Admin.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    NormalizedUserName = "ADMIN@ADMIN.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                });

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d047des3",
                    UserName = "customer@customer.com",
                    Email = "customer@customer.com",
                    FirstName = "Customer",
                    LastName = "Customer",
                    NormalizedUserName = "CUSTOMER@CUSTOMER.COM",
                    PasswordHash = hasher.HashPassword(null, "Pa$$w0rd")
                });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e17e-3b0e-446f-86af-438d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d047cdb9"
                });
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e17e-3b0e-446f-86af-438d56fd7211",
                    UserId = "8e445865-a24d-4543-a6c6-9443d047des3"
                });
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Phone_Book.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
        {

        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)  
        {

        }

        public DbSet<User> Users {get; set; }
        public DbSet<Phones_Book> Phone_Books { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var UserGuid = Guid.Parse("6b305129-ac8a-4a31-9107-ecb8c2c3dc2d");
            var PhoneBookGuid = Guid.Parse("5ccdaab9-8b91-42b0-aede-51d42810d2d8");
            var PhoneNumberGuid1 = Guid.Parse("eab8db3e-5749-4dc5-a877-312216df4c6b");
            var PhoneNumberGuid2 = Guid.Parse("eab8db99-5749-4dc5-a877-312216df4c6b");

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = UserGuid,
                FirstName = "Mahmoud",
                LastName = "Hussein",
                UserName = "hussein98",
                Password = "987654321"

            });

            modelBuilder.Entity<Phones_Book>().HasData(new Phones_Book
            {
                Id = PhoneBookGuid,
                Name = "Ali",
                Address = "assiut",
                UserId = UserGuid

            });
            modelBuilder.Entity<Phone_Number>().HasData(new Phone_Number
            {
                Id = PhoneNumberGuid1,
                Number = "01065232323",
                Phones_BookId = PhoneBookGuid,

            });
            modelBuilder.Entity<Phone_Number>().HasData(new Phone_Number
            {
                Id = PhoneNumberGuid2,
                Number = "01065232323",
                Phones_BookId = PhoneBookGuid,

            });
        }

    }
}

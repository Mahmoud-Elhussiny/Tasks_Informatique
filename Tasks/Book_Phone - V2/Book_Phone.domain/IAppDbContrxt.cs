using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Domain
{
    public interface IAppDbContrxt
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Phones_Book> Phone_Books { get; set; }

    }
}

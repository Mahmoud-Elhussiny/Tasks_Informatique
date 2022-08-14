using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Persistence.Repository
{
    public class Phone_NumberRepository : BaseRepository<Phone_Number>, IPhone_NumberRepository
    {
        public Phone_NumberRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

    }
}

using Microsoft.EntityFrameworkCore;
using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Persistence.Repository
{
    public class Phone_BookRepository : BaseRepository<Phones_Book>,IPhone_BookRepository
    {
        public Phone_BookRepository(AppDbContext appDbContext):base(appDbContext)
        {

        }

        public async Task<IEnumerable<Phones_Book>> GetAllAsync(bool phoneNumbers)
        {
            var PhoneBooks = (phoneNumbers) ?
                await _appDbContext.Phone_Books.Include(ph => ph.Phone_Numbers).ToListAsync() :
               await  _appDbContext.Phone_Books.ToListAsync();
            return PhoneBooks;
        }

        public async Task<Phones_Book> GetAsync(Guid id, bool PhoneNumbers)
        {
            var PhoneBook = (PhoneNumbers) ?
               await _appDbContext.Phone_Books.Include(ph => ph.Phone_Numbers)
               .FirstOrDefaultAsync(p=>p.Id == id) :
               await _appDbContext.Phone_Books.FirstOrDefaultAsync(p => p.Id == id);
            return PhoneBook;
        }
    }
}

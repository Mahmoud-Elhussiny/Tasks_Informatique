using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.interfaces
{
    public interface IPhone_BookRepository : IAsyncRepository<Phones_Book>
    {
        Task<IEnumerable<Phones_Book>> GetAllAsync(bool phoneNumbers);

        Task<Phones_Book> GetAsync(Guid id,bool PhoneNumbers);

        

    }
}

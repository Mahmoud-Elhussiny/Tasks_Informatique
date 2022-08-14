using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.interfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {

        Task<User> CheckUserName(string username);
        Task<User> GetAsync(string username,string password);

    }
}

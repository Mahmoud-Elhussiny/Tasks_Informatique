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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public Task<User> CheckUserName(string username)
        {
            var userexist = _appDbContext.Set<User>()
                .Where(x => x.UserName == username).FirstOrDefaultAsync();
            return userexist;
        }

        public async Task<User> GetAsync(string username, string password)
        {
            var result = await _appDbContext.Set<User>()
                .Where(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();
            if (result == null)
                throw new Exception("This User Is Not Found");
            return result;
            throw new NotImplementedException();
        }
    }
}

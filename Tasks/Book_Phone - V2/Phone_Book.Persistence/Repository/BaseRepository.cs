using Microsoft.EntityFrameworkCore;
using Phone_Book.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Persistence.Repository
{
    public class BaseRepository<T> : IAsyncRepository<T> where T : class
    {
        protected AppDbContext _appDbContext;

        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }


        public async Task<T> AddAsync(T item)
        {
            await _appDbContext.Set<T>().AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }

        public async Task DeleteAsync(T item)
        {
            _appDbContext.Set<T>().Remove(item);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _appDbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(Guid id)
        {
            T result = await _appDbContext.Set<T>().FindAsync(id);
            if (result == null)
                throw new Exception("This Id Is Not Found");
            return result;
        }

        public async Task SaveChangeAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
        public void SaveChange()
        {
            _appDbContext.SaveChanges();
        }

        public async Task UpdateAsync(T item)
        {
            //_appDbContext.Entry(item).State = EntityState.Modified;

            // _appDbContext.Set<T>().Update(item);
            _appDbContext.Update(item);
           
            await _appDbContext.SaveChangesAsync();

        }
    }
}

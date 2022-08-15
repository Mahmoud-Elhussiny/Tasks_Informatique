using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phone_Book.Application.interfaces;
using Phone_Book.Domain;
using Phone_Book.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Persistence.DependencyInjectionPersistence
{
    public static class Dependency_InjectionPersistence
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Phone_Book_Connection"))
                , ServiceLifetime.Transient);

           
            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(IPhone_BookRepository), typeof(Phone_BookRepository));
            services.AddScoped(typeof(IPhone_NumberRepository), typeof(Phone_NumberRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            //services.AddTransient(typeof(IAppDbContrxt), typeof(AppDbContext));
            
            return services;
        }

    }
}

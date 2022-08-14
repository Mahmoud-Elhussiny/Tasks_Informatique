using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Phone_Book.Application.Business.UserManagement.Commands.CreateUserAccount;
using Phone_Book.Application.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.DependencyInjectionApplication
{
    public static class Dependency_InjectionApplication
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            
            
            return services;
        }
    }
}

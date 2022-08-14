using Phone_Book.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.interfaces
{
    public interface IPhone_NumberRepository:IAsyncRepository<Phone_Number>
    {

    }
}

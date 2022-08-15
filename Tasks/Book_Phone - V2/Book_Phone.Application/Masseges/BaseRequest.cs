using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Masseges
{
    public abstract class BaseRequest:BaseMasseges
    {
        public BaseRequest() {  }
        public BaseRequest(Guid correlationId):base()
        {
            _correlationId = correlationId;
        }
    }
}

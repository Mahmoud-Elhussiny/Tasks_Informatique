
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Exceptions
{
    public class WebApiException:Exception
    {
        public WebApiException(){ }

        public WebApiException(string message):base(message){}


    }
}

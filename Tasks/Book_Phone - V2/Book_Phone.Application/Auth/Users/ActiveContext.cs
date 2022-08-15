using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Auth.Users
{
    public class ActiveContext
    {
        public string message { get; set; }
        public bool IsAuthnticated { get; set; }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public string token { get; set; }
        public DateTime expireson { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phone_Book.Application.Auth.JWT_Auth
{
    public static class JWTClaims
    {
        
        public static  string Id = "Ids";
        public static readonly string UserName = "UserNames";
        public static readonly string Password = "Passwords";
        public static readonly string FirstName = "FirstNames";
        public static readonly string LastName = "LastNames";
    }
}

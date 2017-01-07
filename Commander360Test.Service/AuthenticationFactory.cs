using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander360Test.Common.Interfaces;

namespace Commander360Test.Service
{
    public class AuthenticationFactory
    {
        public static IAuthentication CreateAuthentication()
        {
            return new AuthenticationManager();
        }
    }
}

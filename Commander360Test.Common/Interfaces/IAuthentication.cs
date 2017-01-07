using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commander360Test.Common.Interfaces
{
    public interface IAuthentication
    {
        Guid Login(string username, string password);
        void Authenticate(Guid sessionkey);
    }
}

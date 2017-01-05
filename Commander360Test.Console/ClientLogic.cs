using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander360Test.Console.ServiceReference;

namespace Commander360Test.Console
{
    public class ClientLogic : IServerCallback
    {
        public void UpdateData(double result)
        {
            System.Console.WriteLine("{0} -- > {1}", DateTime.Now, result);
        }
    }
}

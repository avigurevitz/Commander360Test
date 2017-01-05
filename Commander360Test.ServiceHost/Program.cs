using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commander360Test.Service;

namespace Commander360Test.ServiceHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var erviceHost = new System.ServiceModel.ServiceHost(typeof(ServerLogic));
            erviceHost.Open();

            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            erviceHost.Close();
        }
    }
}

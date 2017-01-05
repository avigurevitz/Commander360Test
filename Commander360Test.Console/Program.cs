using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Commander360Test.Console.ServiceReference;

namespace Commander360Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new ServerClient(new InstanceContext(new ClientLogic()));
            try
            {
                client.Login("avi", "123456");
                Thread.Sleep(5000);
                client.Start();
            }
            catch (FaultException<UserNotFoundFault> fault)
            {
                System.Console.WriteLine(fault.Detail.Description);
            }
            catch (TimeoutException timeProblem)
            {
                System.Console.WriteLine("The service operation timed out. " + timeProblem.Message);
                client.Abort();
            }
            catch (CommunicationException commProblem)
            {
                System.Console.WriteLine("There was a communication problem. " + commProblem.Message);
                client.Abort();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.ReadKey();
        }
    }
}

using System;
using System.ServiceModel;
using System.Threading;
using Commander360Test.Common.Faults;

namespace Commander360Test.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var binding = new NetTcpBinding();
            var endpoint = new EndpointAddress("net.tcp://localhost:8080/Service");
            var client = new ServerClient(new InstanceContext(new ClientLogic()), binding, endpoint);
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

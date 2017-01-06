using System;

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

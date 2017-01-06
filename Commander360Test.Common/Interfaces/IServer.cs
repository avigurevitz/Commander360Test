using System.ServiceModel;
using Commander360Test.Common.Faults;

namespace Commander360Test.Common.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IServer
    {
        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        void Login(string userName, string password);

        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        void Start();

        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        void Stop();
    }
}
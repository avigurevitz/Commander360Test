using System;
using System.ServiceModel;
using Commander360Test.Common.Faults;

namespace Commander360Test.Common.Interfaces
{
    [ServiceContract(CallbackContract = typeof(IClientCallback))]
    public interface IServer
    {
        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        Guid Login(string userName, string password);

        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        void Start(Guid sessionKey);

        [FaultContract(typeof(UserNotFoundFault))]
        [OperationContract]
        void Stop(Guid sessionKey);
    }
}
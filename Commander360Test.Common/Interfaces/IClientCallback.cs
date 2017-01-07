using System.ServiceModel;
using Commander360Test.Common.Faults;

namespace Commander360Test.Common.Interfaces
{
    [ServiceContract]
    public interface IClientCallback
    {
        [OperationContract(IsOneWay = true)]
        void UpdateData(double result);

        [OperationContract(IsOneWay = true)]
        void UploadData(byte[] buffer);
    }
}
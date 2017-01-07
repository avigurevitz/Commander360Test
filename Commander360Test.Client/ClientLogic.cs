using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Commander360Test.Client
{
    public class ClientLogic : IServerCallback
    {
        #region Members
        public event Action<double> OnDataUpdated;
        public event Action<byte[]> OnStreamReceived;
        private const string NET_TCP_ENDPOINT_ADDRESS = "net.tcp://{0}:8080/Service";
        private const string WSDUAL_HTTP_ENDPOINT_ADDRESS = "http://{0}:8081/Service";
        private readonly IViewManager _viewManager;
        private ServerClient _serverClient;
        private Guid _sessionKey;
        #endregion

        #region ctor
        public ClientLogic(IViewManager viewManager)
        {
            _viewManager = viewManager;
        }
        #endregion

        #region Login
        public void Login(string userName, string password, string IP)
        {
            //var binding = new NetTcpBinding();
            //var endpoint = new EndpointAddress(string.Format(NET_TCP_ENDPOINT_ADDRESS, IP));
            var binding = new WSDualHttpBinding();
            var endpoint = new EndpointAddress(string.Format(WSDUAL_HTTP_ENDPOINT_ADDRESS, IP));
            _serverClient = new ServerClient(new InstanceContext(this), binding, endpoint);

            _sessionKey = _serverClient.Login(userName, password);
            _viewManager.LoggedIn();
        }
        #endregion

        #region StartStreaming
        public void StartStreaming()
        {
            _serverClient.Start(_sessionKey);
        }
        #endregion

        #region StopStreaming
        public void StopStreaming()
        {
            _serverClient.Stop(_sessionKey);
        } 
        #endregion

        #region IServerCallback

        #region UpdateData
        public void UpdateData(double result)
        {
            if (OnDataUpdated != null)
                OnDataUpdated(result);
        }
        #endregion

        #region UploadData
        public void UploadData(byte[] buffer)
        {
            if (OnStreamReceived != null)
                OnStreamReceived(buffer);
        }
        #endregion 

        #endregion
    }
}

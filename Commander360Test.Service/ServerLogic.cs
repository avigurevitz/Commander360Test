using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Commander360Test.Common;
using Commander360Test.Common.Faults;
using Commander360Test.Common.Interfaces;

namespace Commander360Test.Service
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Single, InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServerLogic : IServer
    {
        #region Members

        private byte[] _buffer = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20,
            0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        private readonly Timer _timer;
        private readonly Timer _streamTimer;
        private OperationContext _context;
        private readonly IAuthentication _authenticationManager;

        #endregion

        #region Properties

        public IClientCallback Callback
        {
            get { return _context.GetCallbackChannel<IClientCallback>(); }
        }

        #endregion

        #region ctor

        public ServerLogic()
        {
            _timer = new Timer(3 * 1000);
            _timer.Elapsed += OnTimerOnElapsed;
            _authenticationManager = AuthenticationFactory.CreateAuthentication();

            _streamTimer = new Timer(250);
            _streamTimer.Elapsed += OnStreamTimerElapsed;
        }

        #endregion

        #region Public methods

        #region Login

        public Guid Login(string userName, string password)
        {
            var sessionKey = _authenticationManager.Login(userName, password);
            //_timer.Enabled = true;
            _context = OperationContext.Current;
            return sessionKey;
        }

        #endregion

        #region Start

        public void Start(Guid sessionKey)
        {
            _authenticationManager.Authenticate(sessionKey);
            _streamTimer.Enabled = true;
            Console.WriteLine("{0} --> StreamTimer started", DateTime.Now);
        }

        #endregion

        #region Stop

        public void Stop(Guid sessionKey)
        {
            _authenticationManager.Authenticate(sessionKey);
            _streamTimer.Enabled = false;
            Console.WriteLine("{0} --> StreamTimer ended", DateTime.Now);
        }

        #endregion

        #endregion

        #region OnTimerOnElapsed

        private void OnTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            if (_context.Channel.State == CommunicationState.Closed)
            {
                _context = null;
                return;
            }

            Console.WriteLine("{0} -- {1}", DateTime.Now, _context.SessionId);
            Callback.UpdateData(new Random().Next(1000));
        }

        #endregion

        #region OnStreamTimerElapsed

        private void OnStreamTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (_context == null || _context.Channel == null ||  _context.Channel.State == CommunicationState.Closed)
            {
                _context = null;
                _streamTimer.Enabled = false;
                return;
            }

            var buffer = Encoding.ASCII.GetBytes("Hello from server this is a message for the client to print on the screen");
            Callback.UploadData(buffer);
        }

        #endregion
    }
}

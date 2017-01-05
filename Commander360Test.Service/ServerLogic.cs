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

        private readonly Dictionary<string, string> _users;
        private readonly Timer _timer;
        private OperationContext _context;

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
            _users = new Dictionary<string, string>()
            {
                {"avi", "123456"},
                {"roee", "123456"}
            };

            _timer = new Timer(3 * 1000);
            _timer.Elapsed += OnTimerOnElapsed;
        }

        #endregion

        #region Public methods

        #region Login

        public void Login(string userName, string password)
        {
            if (_users.ContainsKey(userName) == false || _users[userName] != password)
                throw new FaultException<UserNotFoundFault>(new UserNotFoundFault());

            _timer.Enabled = true;
            _context = OperationContext.Current;
        }

        #endregion

        #region Start

        public void Start()
        {
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Commander360Test.Common.Faults;
using Commander360Test.Common.Interfaces;

namespace Commander360Test.Service
{
    public class AuthenticationManager : IAuthentication
    {
        #region Members
        private const double MAX_LOGGED_TIME_IN_MINUTES = 1;
        private readonly Dictionary<string, string> _users;
        private Dictionary<Guid, DateTime> _loggedOn;
        private readonly Timer _timer;
        private object syncObj = new object();
        #endregion

        #region Ctor
        public AuthenticationManager()
        {
            _users = new Dictionary<string, string>()
            {
                {"avi", "123456"},
                {"roee", "123456"}
            };
            _loggedOn = new Dictionary<Guid, DateTime>();
            _timer = new Timer(60 * 1000);
            _timer.Elapsed += OnTimerElapsed;
        }
        #endregion

        #region Public methods

        #region Login
        public Guid Login(string userName, string password)
        {
            if (_users.ContainsKey(userName) == false || _users[userName] != password)
                throw new FaultException<UserNotFoundFault>(new UserNotFoundFault());

            var sessionKey = new Guid();
            _loggedOn.Add(sessionKey, DateTime.Now);
            return sessionKey;
        }
        #endregion

        #region Authenticate
        public void Authenticate(Guid sessionkey)
        {
            if (_loggedOn.ContainsKey(sessionkey) == false)
                throw new FaultException<UserNotFoundFault>(new UserNotFoundFault());
        }
        #endregion

        #endregion

        #region OnTimerElapsed
        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (syncObj)
            {
                var now = DateTime.Now;
                foreach (var item in _loggedOn)
                {
                    if (item.Value.AddMinutes(MAX_LOGGED_TIME_IN_MINUTES) < now)
                        _loggedOn.Remove(item.Key);
                }
            }
        }
        #endregion
    }
}

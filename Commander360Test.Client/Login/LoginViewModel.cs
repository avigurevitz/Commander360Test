using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using Commander360Test.Common.Faults;

namespace Commander360Test.Client.Login
{
    public class LoginViewModel : Screen
    {
        #region Members
        private readonly ClientLogic _logic;
        private string _userName;
        private string _password;
        private string _ip;
        private string _errorMessage;
        #endregion

        #region properties
        public string UserName
        {
            get { return _userName; }
            set
            {
                if (value == _userName)
                    return;

                _userName = value;
                NotifyOfPropertyChange(() => UserName);
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                if (value == _password)
                    return;

                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        public string IP
        {
            get { return _ip; }
            set
            {
                if (value == _ip)
                    return;

                _ip = value;
                NotifyOfPropertyChange(() => IP);
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                if (value == _errorMessage)
                    return;

                _errorMessage = value;
                NotifyOfPropertyChange(() => ErrorMessage);
            }
        }
        #endregion

        #region Ctor
        public LoginViewModel(ClientLogic logic)
        {
            _logic = logic;
        }
        #endregion

        #region Login
        public void Login()
        {
            try
            {
                _logic.Login(UserName, Password, IP);
            }
            catch (FaultException<UserNotFoundFault> fault)
            {
                ErrorMessage = fault.Detail.Description;
            }
        } 
        #endregion
    }
}

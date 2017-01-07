using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Commander360Test.Client.Shell
{
    public class ShellViewModel : Conductor<object>, IViewManager
    {
        private readonly ClientLogic _logic;

        public string Title { get; private set; }

        public ShellViewModel()
        {
            var binding = new NetTcpBinding();
            var endpoint = new EndpointAddress("net.tcp://localhost:8080/Service");
            _logic = new ClientLogic(this);
            var client = new ServerClient(new InstanceContext(_logic), binding, endpoint);
        }

        public void LoggedIn()
        {
            ActivateItem(new Main.MainViewModel(_logic));
        }

        protected override void OnActivate()
        {
            ActivateItem(new Login.LoginViewModel(_logic));
            base.OnActivate();
            Title = string.Format("Commander360Test {0}", Assembly.GetExecutingAssembly().GetName().Version);
        }
    }
}

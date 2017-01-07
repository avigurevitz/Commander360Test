using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;

namespace Commander360Test.Client.Main
{
    public class MainViewModel : Screen
    {
        #region Members
        private readonly ClientLogic _logic;
        private string _data;
        private ObservableCollection<string> _stream; 
        #endregion

        #region properties

        public string Data
        {
            get { return _data; }
            set
            {
                if (value == _data)
                    return;

                _data = value;
                NotifyOfPropertyChange(() => Data);
            }
        }

        public ObservableCollection<string> Stream { get; set; }

        #endregion

        #region Ctor
        public MainViewModel(ClientLogic logic)
        {
            _logic = logic;
            _logic.OnDataUpdated += OnDataUpdated;
            _logic.OnStreamReceived += OnStreamReceived;
            Stream = new ObservableCollection<string>();
        }
        #endregion

        #region Start

        public void Start()
        {
            _logic.StartStreaming();
        }

        #endregion

        #region Stop

        public void Stop()
        {
            _logic.StopStreaming();
        }

        #endregion

        #region Clear

        public void Clear()
        {
            Stream.Clear();
        }

        #endregion

        #region OnDataUpdated
        private void OnDataUpdated(double data)
        {
            Data = string.Format("{0} --> {1}", DateTime.Now, data);
        }
        #endregion

        #region OnStreamReceived

        private void OnStreamReceived(byte[] buffer)
        {
            Stream.Add(string.Format("{0} --> {1}" , DateTime.Now, Encoding.ASCII.GetString(buffer)));
        }

        #endregion
    }
}

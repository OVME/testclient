using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Command;
using SOAP;
using ViewModel.Annotations;

namespace ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {

        #region fields
        private Client _client;
        private RelayCommand _sendToServiseAndGetIdCommand;
        private RelayCommand _getProcessStatusCommand;
        private RelayCommand _getResultCommand;
        private string _reqString;
        private int _returnedId;
        private string _returnedStatus;
        private string _returnedResult;
        private int _idForStatus;
        private int _idForResult;
        private int _jobId;
        private RelayCommand _jobStatusRequestCommand;
        private string _jobStatus;
        private int _jobIdForRequest;

        #endregion
        #region properties
        public RelayCommand SendToServiceAndGetIdCommand
        {
            get
            {
                return _sendToServiseAndGetIdCommand ??
                       (_sendToServiseAndGetIdCommand = new RelayCommand(SendToServiseAndGetId));
            }
        }
        

        public RelayCommand GetProcessStatusCommand
        {
            get
            {
                return _getProcessStatusCommand ??
                       (_getProcessStatusCommand = new RelayCommand(GetProcessStatus));
            }
        }

        public RelayCommand GetResultCommand
        {
            get
            {
                return _getResultCommand ??
                       (_getResultCommand = new RelayCommand(GetResult));
            }
        }

        public RelayCommand JobStatusRequestCommand
        {
            get { return _jobStatusRequestCommand ?? (_jobStatusRequestCommand = new RelayCommand(JobStatusRequest)); }
            
        }

        
        public string ReqString
        {
            get { return _reqString; }
            set
            {
                _reqString = value;
                OnPropertyChanged("ReqString");
            }
        }

        public int ReturnedId
        {
            get { return _returnedId; }
            set
            {
                _returnedId = value;
                OnPropertyChanged("ReturnedId");
            }
        }

        public string ReturnedStatus
        {
            get { return _returnedStatus; }
            set
            {
                _returnedStatus = value;
                OnPropertyChanged("ReturnedStatus");
            }
        }

        public string ReturnedResult
        {
            get { return _returnedResult; }
            set
            {
                _returnedResult = value;
                OnPropertyChanged("ReturnedResult");
            }
        }

        public int IdForStatus
        {
            get { return _idForStatus; }
            set
            {
                _idForStatus = value;
                OnPropertyChanged("IdForStatus");
            }
        }

        public int IdForResult
        {
            get { return _idForResult; }
            set
            {
                _idForResult = value;
                OnPropertyChanged("IdForResult");
            }
        }

        public int JobId
        {
            get { return _jobId; }
            set
            {
                _jobId = value;
                OnPropertyChanged("JobId");
                JobIdForRequest = value;
            }
        }

        public int JobIdForRequest
        {
            get { return _jobIdForRequest; }
            set
            {
                _jobIdForRequest = value;
                OnPropertyChanged("JobIdForRequest");
            }
        }

        public string JobStatus
        {
            get { return _jobStatus; }
            set
            {
                _jobStatus = value;
                OnPropertyChanged("JobStatus");
            }
        }

        #endregion
        #region events
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region methods
        public MainViewModel()
        {
            _client = new Client();
        }

        public void SendToServiseAndGetId()
        {
            string res = _client.GetRId(ReqString);
            ReturnedId = Int32.Parse(res.Split(' ')[0]);
            IdForStatus = ReturnedId;
            IdForStatus = ReturnedId;
            JobId = Int32.Parse(res.Split(' ')[1]);

        }

        

        public void GetProcessStatus()
        {
            ReturnedStatus = _client.GetStatus(IdForStatus);
        }

        public void GetResult()
        {
            ReturnedResult = _client.GetResult(IdForResult);
        }

        private void JobStatusRequest()
        {
            JobStatus = _client.GetProcessStatus(JobId);
        }



        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        

        #endregion

        public void OnViewClosing(object sender, EventArgs e)
        {
            _client.CloseConnection();
        }
    }
}

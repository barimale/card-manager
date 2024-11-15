using card_manager_ui.Commands;
using card_manager_ui.Services;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class DeleteViewModel : ViewModelBase
    {
        public readonly IDataService dataService;

        public DeleteViewModel(IDataService dataService)
            : this()
        {
            this.dataService = dataService;
        }

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _serialNumber;
        public string SerialNumber
        {
            get
            {
                return _serialNumber;
            }
            set
            {
                _serialNumber = value;
                OnPropertyChanged(nameof(SerialNumber));
            }
        }

        private string _identifier;
        public string Identifier
        {
            get
            {
                return _identifier;
            }
            set
            {
                _identifier = value;
                OnPropertyChanged(nameof(Identifier));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand DeleteCommand { get; }

        public DeleteViewModel()
        {
            DeleteCommand = new DeleteCommand(this);
        }
    }
}

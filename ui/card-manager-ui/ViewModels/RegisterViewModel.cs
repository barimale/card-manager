using card_manager_ui.Commands;
using card_manager_ui.Services;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public readonly IStarWarsService dataService;

        public RegisterViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }

        public RegisterViewModel(IStarWarsService dataService)
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

        public ICommand LoginCommand { get; }
    }
}

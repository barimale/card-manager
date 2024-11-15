using card_manager_ui.Commands;
using card_manager_ui.Services;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class RegisterViewModel : ViewModelBase
    {
        public readonly IDataService dataService;

        public RegisterViewModel()
        {
            LoginCommand = new LoginCommand(this);
        }

        public RegisterViewModel(IDataService dataService)
            : this()
        {
            this.dataService = dataService;
        }

        private string _accountNumber;
        public string AccountNumber
        {
            get
            {
                return _accountNumber;
            }
            set
            {
                _accountNumber = value;
                OnPropertyChanged(nameof(AccountNumber));
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

        private string _pin;
        public string PIN
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;
                OnPropertyChanged(nameof(PIN));
            }
        }

        public ICommand LoginCommand { get; }
    }
}

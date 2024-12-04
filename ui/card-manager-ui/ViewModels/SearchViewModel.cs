using card_manager_ui.Commands;
using card_manager_ui.Services;
using card_manager_ui.ViewModels.Abstractions;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        public readonly IDataService dataService;

        private SearchViewModel()
        {
            SearchCommand = new SearchCommand(this);
        }

        public SearchViewModel(IDataService dataService)
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
                _serialNumber = string.Empty;
                _identifier = string.Empty;
                OnPropertyChanged(nameof(Identifier));
                OnPropertyChanged(nameof(SerialNumber));
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
                _accountNumber = string.Empty;
                _identifier = string.Empty;
                OnPropertyChanged(nameof(Identifier));
                OnPropertyChanged(nameof(SerialNumber));
                OnPropertyChanged(nameof(AccountNumber));
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
                _accountNumber = string.Empty;
                _serialNumber = string.Empty;
                OnPropertyChanged(nameof(Identifier));
                OnPropertyChanged(nameof(SerialNumber));
                OnPropertyChanged(nameof(AccountNumber));

            }
        }

        public ICommand SearchCommand { get; }
    }
}

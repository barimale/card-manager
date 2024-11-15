using card_manager_ui.Commands;
using card_manager_ui.Services;
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

        private string _username;
        public string AccountNumber
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
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

        public ICommand SearchCommand { get; }
    }
}

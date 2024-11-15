using card_manager_ui.Commands;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
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

        public ICommand SearchCommand { get; }

        public SearchViewModel()
        {
            SearchCommand = new SearchCommand(this);
        }
    }
}

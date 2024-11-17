using card_manager_ui.Commands;
using card_manager_ui.Services;
using card_manager_ui.ViewModels.Abstractions;
using System.Windows.Input;

namespace card_manager_ui.ViewModels
{
    public class DeleteViewModel : ViewModelBase
    {
        public readonly IDataService dataService;

        private DeleteViewModel()
        {
            DeleteCommand = new DeleteCommand(this);
        }

        public DeleteViewModel(IDataService dataService)
            : this()
        {
            this.dataService = dataService;
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

        public ICommand DeleteCommand { get; }
    }
}

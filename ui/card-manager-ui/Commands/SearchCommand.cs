using card_manager_ui.Services;
using card_manager_ui.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using static card_manager_ui.Services.DataHttpClient;

namespace card_manager_ui.Commands
{
    public class SearchCommand : ICommand
    {
        private readonly SearchViewModel _viewModel;

        public SearchCommand(SearchViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.AccountNumber) ||
                !string.IsNullOrEmpty(_viewModel.SerialNumber) ||
                !string.IsNullOrEmpty(_viewModel.Identifier);
        }

        public async void Execute(object parameter)
        {
            GetCardResult? result = null;

            // WIP map to object return object
            if(!string.IsNullOrEmpty(_viewModel.AccountNumber))
            {
                result = await _viewModel.dataService.GetByAccountNumber(_viewModel.AccountNumber);
            }
            else if (!string.IsNullOrEmpty(_viewModel.SerialNumber))
            {
                result = await _viewModel.dataService.GetBySerialNumber(_viewModel.SerialNumber);
            }
            else if (!string.IsNullOrEmpty(_viewModel.Identifier))
            {
                result = await _viewModel.dataService.GetByIdentifier(_viewModel.Identifier);
            }

            if (result is null || result.Card is null)
            {
                MessageBox.Show("Entity not found.");
            }
            else{
                MessageBox.Show($"AccountNumber: {result.Card.AccountNumber}\nSerial number: {result.Card.SerialNumber}\nID: {result.Card.Id}", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

using card_manager_ui.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace card_manager_ui.Commands
{
    public class RegisterCommand : ICommand
    {
        private readonly RegisterViewModel _viewModel;

        public RegisterCommand(RegisterViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.AccountNumber) &&
                !string.IsNullOrEmpty(_viewModel.PIN) &&
                !string.IsNullOrEmpty(_viewModel.SerialNumber);
        }

        public async void Execute(object parameter)
        {
            var res = await _viewModel.dataService.Create(
                _viewModel.AccountNumber,
                _viewModel.SerialNumber,
                _viewModel.PIN);

            if(res is null)
            {
                MessageBox.Show("Entity not created.", "Warning",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                MessageBox.Show($"Entity created.", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

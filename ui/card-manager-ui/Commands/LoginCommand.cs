using card_manager_ui.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace card_manager_ui.Commands
{
    public class LoginCommand : ICommand
    {
        private readonly RegisterViewModel _viewModel;

        public LoginCommand(RegisterViewModel viewModel)
        {
            _viewModel = viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_viewModel.Username) &&
                !string.IsNullOrEmpty(_viewModel.Password) &&
                !string.IsNullOrEmpty(_viewModel.SerialNumber);
        }

        public async void Execute(object parameter)
        {
            var res = await _viewModel.dataService.Create(
                _viewModel.Username,
                _viewModel.SerialNumber,
                _viewModel.Password);

            MessageBox.Show($"Result: {res}", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

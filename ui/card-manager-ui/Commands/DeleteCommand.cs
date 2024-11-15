using card_manager_ui.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace card_manager_ui.Commands
{
    public class DeleteCommand : ICommand
    {
        private readonly DeleteViewModel _viewModel;

        public DeleteCommand(DeleteViewModel viewModel)
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
            var res = await _viewModel.dataService.Delete(_viewModel.Identifier);

            MessageBox.Show($"Result: {res}", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

using card_manager_ui.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

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
            return !string.IsNullOrEmpty(_viewModel.Username) ||
                !string.IsNullOrEmpty(_viewModel.SerialNumber) ||
                !string.IsNullOrEmpty(_viewModel.Identifier);
        }

        public void Execute(object parameter)
        {
            MessageBox.Show($"Username: {_viewModel.Username}\nSerial number: {_viewModel.SerialNumber}\nID: {_viewModel.Identifier}", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}

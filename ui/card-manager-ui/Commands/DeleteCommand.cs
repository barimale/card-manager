using PasswordBoxMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace PasswordBoxMVVM.Commands
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

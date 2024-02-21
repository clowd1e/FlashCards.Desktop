using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCards.Desktop.Commands
{
    public class ChangeToRegFormCommand : CommandBase
    {
        private LoginViewModel _loginViewModel;
        public override void Execute(object? parameter)
        {
            ChangeWindow();
        }

        private void ChangeWindow()
        {
            RegistrationWindow mainWindow = new RegistrationWindow()
            {
                DataContext = new RegistrationViewModel()
            };

            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = mainWindow;
            mainWindow.Show();
        }

        public ChangeToRegFormCommand(LoginViewModel loginViewModel)
        {
            _loginViewModel = loginViewModel;
        }
    }
}

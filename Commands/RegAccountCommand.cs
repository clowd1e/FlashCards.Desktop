using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Desktop.Commands
{
    public class RegAccountCommand : CommandBase
    {
        private RegistrationViewModel _registrationViewModel;
        public override void Execute(object? parameter)
        {
            // checking all stuff
            bool test = true;

            OpenAlertWindow(test);
        }

        private void OpenAlertWindow(bool isSucceed)
        {
            string headerText = isSucceed ? "Success" : "Error";
            string infoText = isSucceed ? "Your account has been created successfully" : "Oops... Something went wrong";

            AlertWindow alertWindow = new AlertWindow();
            alertWindow.DataContext = new AlertViewModel(alertWindow, headerText, infoText);

            alertWindow.ShowDialog();
        }

        public RegAccountCommand(RegistrationViewModel registrationViewModel)
        {
            _registrationViewModel = registrationViewModel;
        }
    }
}

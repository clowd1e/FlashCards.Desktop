using FlashCards.Desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlashCards.Desktop.ViewModels
{
    public class AlertViewModel : ViewModelBase
    {
        private string headerText;
        public string HeaderText
        {
            get => headerText;
            set
            {
                headerText = value;
                OnPropertyChanged(nameof(HeaderText));
            }
        }

        private string infoText;
        public string InfoText
        {
            get => infoText;
            set
            {
                infoText = value;
                OnPropertyChanged(nameof(InfoText));
            }
        }

        public ICommand Continue { get; }

        public AlertViewModel(Window window, string headerText, string infoText)
        {
            HeaderText = headerText;
            InfoText = infoText;
            Continue = new ExitAlertCommand(window, new LoginWindow(), new LoginViewModel());
        }
    }
}

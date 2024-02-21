using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCards.Desktop.Commands
{
    public class ExitAlertCommand : CommandBase
    {
        private Window _window;
        private Window _windowToChange = null;
        public override void Execute(object? parameter)
        {
            if (_windowToChange is not null)
            {
                _window.Close();

                Application.Current.MainWindow.Close();
                Application.Current.MainWindow = _windowToChange;
                _windowToChange.Show();
            }
            else
            {
                _window.Close();
            }
        }

        public ExitAlertCommand(Window window)
        {
            _window = window;
        }

        public ExitAlertCommand(Window window, Window windowToChange, ViewModelBase viewModel)
        {
            _window = window;
            _windowToChange = windowToChange;
            _windowToChange.DataContext = viewModel;
        }
    }
}

using FlashCards.Desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCards.Desktop.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        
        public ICommand SingUp { get; }
        public LoginViewModel()
        {
            SingUp = new ChangeToRegFormCommand(this);
        }
    }
}

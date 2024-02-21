using FlashCards.Desktop.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCards.Desktop.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        public ICommand Submit { get; }
        public RegistrationViewModel()
        {
            Submit = new RegAccountCommand(this);
        }
    }
}

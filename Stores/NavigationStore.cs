using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Desktop.Stores
{
    public class NavigationStore
    {
        private ViewModelBase currentFlashCard;
        public ViewModelBase CurrentFlashCard
        {
            get => currentFlashCard;
            set
            {
                currentFlashCard = value;
                OnCurrentFlashCardChanged();
            }
        }

        public event Action CurrentFlashCardChanged;

        private void OnCurrentFlashCardChanged()
        {
            CurrentFlashCardChanged?.Invoke();
        }
    }
}

using FlashCards.Desktop.Models;
using FlashCards.Desktop.Models.Identity;
using FlashCards.Desktop.Repositories;
using FlashCards.Desktop.RepositoryContracts;
using FlashCards.Desktop.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FlashCards.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public ViewModelBase CurrentFlashCard => navigationStore.CurrentFlashCard;
        public MainViewModel()
        {
            navigationStore = new NavigationStore();
            navigationStore.CurrentFlashCard = new FlashCardFrontViewModel("Show");

            navigationStore.CurrentFlashCardChanged += OnCurrentFlashCardChanged;
        }

        private string leftCards = "13 left";
        public string LeftCards
        {
            get { return leftCards; }
            set
            {
                leftCards = value;
                OnPropertyChanged(nameof(LeftCards));
            }
        }

        private void OnCurrentFlashCardChanged()
        {
            OnPropertyChanged(nameof(CurrentFlashCard));
        }
    }
}

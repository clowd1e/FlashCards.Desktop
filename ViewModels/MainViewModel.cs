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
            navigationStore.CurrentFlashCard = new FlashCardFrontViewModel();

            navigationStore.CurrentFlashCardChanged += OnCurrentFlashCardChanged;
        }

        private string cardFrontSide = "Some word";
        public string CardFrontSide
        {
            get { return cardFrontSide; }
            set
            {
                cardFrontSide = value;
                OnPropertyChanged(nameof(CardFrontSide));
            }
        }

        private string cardBackSide;
        public string CardBackSide
        {
            get { return cardBackSide; }
            set
            {
                cardBackSide = value;
                OnPropertyChanged(nameof(CardBackSide));
            }
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

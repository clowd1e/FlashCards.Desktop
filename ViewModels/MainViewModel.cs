using FlashCards.Desktop.Commands;
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
using System.Windows.Input;

namespace FlashCards.Desktop.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly NavigationStore navigationStore;

        public ViewModelBase CurrentFlashCard => navigationStore.CurrentFlashCard;

        public ICommand Rate { get; }

        public MainViewModel()
        {
            Flashcard testFlashcard = new Flashcard() { MainSide = "Show", OppositeSide = "Allow or cause (something) to be visible." };
            Flashcard secondTestFlashcard = new Flashcard() { MainSide = "Success", OppositeSide = "The accomplishment of an aim or purpose." };
            
            navigationStore = new NavigationStore();
            navigationStore.CurrentFlashCard = new FlashCardFrontViewModel(navigationStore, this , testFlashcard);

            Rate = new RateDifficultyCommand(navigationStore, this, testFlashcard, secondTestFlashcard);

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

        private bool isFeedbackPanelVisibile = false;
        public bool IsFeedbackPanelVisibile
        {
            get { return isFeedbackPanelVisibile; }
            set
            {
                isFeedbackPanelVisibile = value;
                OnPropertyChanged(nameof(IsFeedbackPanelVisibile));
            }
        }

        private void OnCurrentFlashCardChanged()
        {
            OnPropertyChanged(nameof(CurrentFlashCard));
        }
    }
}

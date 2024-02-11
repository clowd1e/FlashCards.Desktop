using FlashCards.Desktop.Models;
using FlashCards.Desktop.Stores;
using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCards.Desktop.Commands
{
    public class RateDifficultyCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private MainViewModel _mainViewModel;
        private Flashcard _flashcard;
        private Flashcard _newFlashcard;

        public RateDifficultyCommand(NavigationStore navigationStore, MainViewModel mainViewModel, Flashcard flashcard, Flashcard newFlashcard)
        {
            _navigationStore = navigationStore;
            _mainViewModel = mainViewModel;
            _flashcard = flashcard;
            _newFlashcard = newFlashcard;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentFlashCard = new FlashCardFrontViewModel(_navigationStore, _mainViewModel, _newFlashcard);
            _mainViewModel.IsFeedbackPanelVisibile = false;

            // Rate flashcard difficulty
            _flashcard.EFactor = Convert.ToSingle(parameter);
        }
    }
}

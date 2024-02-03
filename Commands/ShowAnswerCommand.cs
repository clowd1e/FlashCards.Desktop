using FlashCards.Desktop.Models;
using FlashCards.Desktop.Stores;
using FlashCards.Desktop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Desktop.Commands
{
    public class ShowAnswerCommand : CommandBase
    {
        private NavigationStore _navigationStore;
        private MainViewModel _mainViewModel;
        private Flashcard _flashcard;
        public ShowAnswerCommand(NavigationStore navigationStore, MainViewModel mainViewModel, Flashcard flashcard)
        {
            _navigationStore = navigationStore;
            _mainViewModel = mainViewModel;
            _flashcard = flashcard;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentFlashCard = new FlashCardBackViewModel(_flashcard);
            _mainViewModel.IsFeedbackPanelVisibile = true;
        }
    }
}

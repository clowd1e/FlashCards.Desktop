using FlashCards.Desktop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Desktop.ViewModels
{
    public class FlashCardBackViewModel : ViewModelBase
    {
        private string cardFrontSideText;
        public string CardFrontSideText
        {
            get { return cardFrontSideText; }
            set
            {
                cardFrontSideText = value;
                OnPropertyChanged(nameof(CardFrontSideText));
            }
        }

        private string cardBackSideText;
        public string CardBackSideText
        {
            get { return cardBackSideText; }
            set
            {
                cardBackSideText = value;
                OnPropertyChanged(nameof(CardBackSideText));
            }
        }

        public FlashCardBackViewModel(Flashcard flashcard)
        {
            CardFrontSideText = flashcard.MainSide;
            CardBackSideText = flashcard.OppositeSide;
        }
    }
}

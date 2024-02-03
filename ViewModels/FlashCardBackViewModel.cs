using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCards.Desktop.ViewModels
{
    public class FlashCardBackViewModel : ViewModelBase
    {
        FlashCardBackViewModel() { }

        private string cardFrontSideText = "Show";
        public string CardFrontSideText
        {
            get { return cardFrontSideText; }
            set
            {
                cardFrontSideText = value;
                OnPropertyChanged(nameof(CardFrontSideText));
            }
        }

        private string cardBackSideText = "Вистава";
        public string CardBackSideText
        {
            get { return cardBackSideText; }
            set
            {
                cardBackSideText = value;
                OnPropertyChanged(nameof(CardBackSideText));
            }
        }
    }
}

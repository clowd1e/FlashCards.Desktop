﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlashCards.Desktop.ViewModels
{
    public class FlashCardFrontViewModel : ViewModelBase
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

        public ICommand ShowAnswer { get; }
        public FlashCardFrontViewModel(string frontText)
        {
            CardFrontSideText = frontText;

            ShowAnswer = new ShowAnswerCommand();
        }
    }
}

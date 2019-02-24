using System;
using System.Windows.Input;


namespace BookmarkPlayer.Desktop.Windows.Windows.Controls
{

    public class ShelfViewModel
    {
        private static Random _random = new Random();
        public ShelfViewModel(string title)
        {
            Title = title;
            Progress = (short)_random.Next(0, 100);
            IsProgressVisible = true;
        }

        public string Title { get; }
        public short Progress { get; }
        public bool IsProgressVisible { get; }

        public ICommand Locate { get; }
    }
}

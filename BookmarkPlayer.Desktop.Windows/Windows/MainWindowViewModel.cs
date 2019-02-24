using Akka.Actor;
using BookmarkPlayer.Desktop.Windows.Windows.Controls;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BookmarkPlayer.Desktop.Windows
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {
            _system = CreateActorSystem();
            _system.ActorOf<Actors.Shell>(nameof(Actors.Shell));
        }


        private ActorSystem CreateActorSystem()
        {
            return ActorSystem.Create("BookmarkPlayerSystem");
        }

        public List<LibraryViewModel> Libraries => new List<LibraryViewModel>
        {
            new LibraryViewModel("Programming"),
            new LibraryViewModel("Movies")
        };

        private ActorSystem _system;


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged
    }

    public class LibraryViewModel
    {

        public LibraryViewModel(string header)
        {
            Header = header;
            Content = new List<ShelfViewModel>
            {
                new ShelfViewModel("Akka .Net"),
                new ShelfViewModel("OOD"),
            };
        }


        public string Header { get; }
        public List<ShelfViewModel> Content { get; }
    }
}

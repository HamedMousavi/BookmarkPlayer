using Akka.Actor;
using BookmarkPlayer.Desktop.Windows;
using MemoRun.Windows.Desktop.Actors;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace MemoRun.Windows.Desktop.Views
{

    public class MainWindowViewModel : INotifyPropertyChanged, IEventSubscriber<Added<Shelf>>
    {

        public MainWindowViewModel(IActorRef library)
        {
            Libraries = new ObservableCollection<LibraryViewModel>();

            _library = library;
            _library.Tell(new Inform(this));
        }

        public void When(Added<Shelf> e)
        {
            Libraries.Add(new LibraryViewModel(e.Item.Title));
            //FirePropertyChanged(nameof(Libraries));
        }


        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void FirePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion PropertyChanged


        public ObservableCollection<LibraryViewModel> Libraries { get; }


        public ICommand AddLibraryClicked {
            get {
                return new RelayCommand(e => {
                    _library.Tell(new Add<Actors.Shelf>(new Actors.Shelf("New Library")));
                    FirePropertyChanged(nameof(Libraries));
                }, e => true);
            }
        }


        private readonly IActorRef _library;
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

using Akka.Actor;
using BookmarkPlayer.Desktop.Windows;
using MemoRun.Windows.Desktop.Actors.Commands;
using MemoRun.Windows.Desktop.Actors.Events;
using MemoRun.Windows.Desktop.Resources;
using System.Collections.ObjectModel;
using System.Windows.Input;


namespace MemoRun.Windows.Desktop.Views
{

    public class MainWindowViewModel : IEventSubscriber<Added<Library>>
    {

        public MainWindowViewModel(IActorRef library)
        {
            _libDirector = library;
            _libDirector.Tell(new SendEventsTo(this));
        }


        public void When(Added<Library> e)
        {
            Libraries.Add(new LibraryViewModel(e.Item.Title));
        }


        public ICommand AddLibraryClicked => 
            new RelayCommand(e => { _libDirector.Tell(new Add<Library>("New Library")); }, e => true);


        public ObservableCollection<LibraryViewModel> Libraries { get; }
            = new ObservableCollection<LibraryViewModel>();


        private readonly IActorRef _libDirector;
    }
}

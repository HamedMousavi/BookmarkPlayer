using Akka.Actor;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BookmarkPlayer.Desktop.Windows
{

    public class MainWindowViewModel : INotifyPropertyChanged
    {

        private ActorSystem _system;


        public MainWindowViewModel()
        {
            _system = CreateActorSystem();
            _system.ActorOf<Actors.Shell>(nameof(Actors.Shell));
        }


        private ActorSystem CreateActorSystem()
        {
            return ActorSystem.Create("BookmarkPlayerSystem");
        }


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion PropertyChanged
    }
}

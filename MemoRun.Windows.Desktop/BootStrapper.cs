using Akka.Actor;
using Grace.DependencyInjection;
using MemoRun.Windows.Desktop.Views;


namespace MemoRun.Windows.Desktop
{

    public class BootStrapper
    {

        private DependencyInjectionContainer _container;
        private ActorSystem _system;

        public void Bootstrap()
        {
            _container = new DependencyInjectionContainer();
            _container.Configure(c => c.ExportInstance(new MainWindowViewModel(Create<Actors.Library>())).As<MainWindowViewModel>().Lifestyle.Singleton());

            //_container.Configure(c =>
            //{
            //    c.ExportInstance(CreatePlaylistContainerStore()).As<IPlaylistContainerStore>().Lifestyle.Singleton();
            //});
        }

        private IActorRef Create<T>() where T : ActorBase, new()
        {
            if (_system == null) _system = ActorSystem.Create("MemoRunSystem");
            var props = Props.Create<T>().WithDispatcher("akka.actor.synchronized-dispatcher");
            return _system.ActorOf(props);
        }

        public T Locate<T>()
        {
            return _container.Locate<T>();
        }
    }
}

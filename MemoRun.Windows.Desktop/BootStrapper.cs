using Akka.Actor;
using Akka.Configuration;
using Akka.Persistence.Sqlite;
using Grace.DependencyInjection;
using MemoRun.Windows.Desktop.Views;
using System;
using System.IO;

namespace MemoRun.Windows.Desktop
{

    public class BootStrapper
    {

        private DependencyInjectionContainer _container;
        private ActorSystem _system;
        private IActorRef _director;

        public void Bootstrap()
        {
            _container = new DependencyInjectionContainer();
            _container.Configure(c => c
                .ExportInstance(new MainWindowViewModel(CreateLibraryDirector()))
                .As<MainWindowViewModel>().Lifestyle.Singleton());
        }


        private IActorRef CreateLibraryDirector()
        {
            _director = Create<Actors.LibraryDirector>();
            return _director;
        }


        private IActorRef Create<T>() where T : ActorBase, new()
        {

            var startupPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
            var settingFilePath = $"{startupPath}akka.hocon";
            var configText = string.Empty;
            using (var stream = new FileStream(settingFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var reader = new StreamReader(stream))
                {
                    configText = reader.ReadToEnd();
                }
            }

            configText = configText.Replace("[datadir]", (startupPath + "data" + Path.DirectorySeparatorChar).Replace("\\", "/"));

            var config = ConfigurationFactory.ParseString(configText);
            if (_system == null) _system = ActorSystem.Create("MemoRunSystem", config);
            Akka.Persistence.Sqlite.SqlitePersistence.Get(_system);

            var props = Props.Create<T>().WithDispatcher("akka.actor.synchronized-dispatcher");
            return _system.ActorOf(props);
        }

        public T Locate<T>()
        {
            return _container.Locate<T>();
        }
    }
}

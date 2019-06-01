using Akka.Persistence;


namespace MemoRun.Windows.Desktop.Actors
{

    public class LibraryManager : ReceivePersistentActor
    {

        public LibraryManager(string libraryName)
        {
            PersistenceId = new RandomName().StartWith(libraryName);
        }


        public override string PersistenceId { get; }
    }
}

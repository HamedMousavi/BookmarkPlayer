using Akka.Persistence;
using MemoRun.Windows.Desktop.Resources;


namespace MemoRun.Windows.Desktop.Actors
{

    public class LibraryManager : ReceivePersistentActor
    {

        public LibraryManager(Library library)
        {
            PersistenceId = new RandomName().StartWith(library.Title);
        }


        public override string PersistenceId { get; }
    }
}

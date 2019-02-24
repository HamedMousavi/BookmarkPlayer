using Akka.Actor;
using System.Diagnostics;


namespace BookmarkPlayer.Desktop.Windows.Actors
{

    public class Shell : ReceiveActor
    {

        public Shell()
        {
            Receive<Messages.Run>(Run);
        }


        private bool Run(Messages.Run runnable)
        {
            Debug.WriteLine($"Now playing {runnable.Path}");
            return true;
        }


        #region Messages
        public class Messages
        {
            public class Run
            {

                public Run(string path)
                {
                    Path = path;
                }


                public string Path { get; }
            }
        }

        #endregion
    }
}

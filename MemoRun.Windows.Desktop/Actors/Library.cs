using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Text;

namespace MemoRun.Windows.Desktop.Actors
{
    public class LibraryManager : ReceiveActor
    {
        public string Id { get; }
    }
}

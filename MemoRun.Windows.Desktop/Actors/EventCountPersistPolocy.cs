namespace MemoRun.Windows.Desktop.Actors
{

    public class EventCountPersistPolocy : SnapshotPersistPolocy
    {

        public EventCountPersistPolocy(int snapshotEventInterval)
        {
            _snapshotEventInterval = snapshotEventInterval;
        }


        protected override void OnSnapshotTaken()
        {
            _eventCount = 0;
        }


        protected override bool ShouldTakeSnapshot<TEvent>(TEvent e)
        {
            return _snapshotEventInterval > 0 && ++_eventCount >= _snapshotEventInterval;
        }


        private int _eventCount;
        private readonly int _snapshotEventInterval;
    }
}

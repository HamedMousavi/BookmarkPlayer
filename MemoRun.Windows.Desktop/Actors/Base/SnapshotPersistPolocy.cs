using System;


namespace MemoRun.Windows.Desktop.Actors
{

    public abstract class SnapshotPersistPolocy
    {

        internal void Enforce<TEvent>(TEvent e)
        {
            if (_saveSnapshot != null && ShouldTakeSnapshot(e))
            {
                _saveSnapshot();
                OnSnapshotTaken();
            }
        }


        protected virtual void OnSnapshotTaken() { }
        protected abstract bool ShouldTakeSnapshot<TEvent>(TEvent e);


        internal void WhenShouldTakeSnapshot(Action saveSnapshot)
        {
            _saveSnapshot = saveSnapshot;
        }


        private Action _saveSnapshot;
    }
}

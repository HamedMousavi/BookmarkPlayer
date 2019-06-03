using System;
using Akka.Persistence;


namespace MemoRun.Windows.Desktop.Actors
{

    public abstract class AutoSnapshotActor : ReceivePersistentActor
    {

        public void EnableEventStore<TEvent>(Action<TEvent> onEventStored, Action<TEvent> onEventLoaded)
        {
            Command<TEvent>(e => Persist(e, ec =>
            {
                onEventStored?.Invoke(e);
                _snapshotPersistPolocy?.Enforce(ec);
            }));

            if (onEventLoaded != null) Recover<TEvent>(e => onEventLoaded(e));
        }


        public void EnableSnapshot<TSnapshot>(SnapshotPersistPolocy persistPolocy, IPersistSerializer snapshotSerializer, Func<object> getSnapshotData, Action<TSnapshot> onSnapshotLoaded)
        {
            _snapshotPersistPolocy = persistPolocy;
            if (getSnapshotData != null)
            {
                _snapshotPersistPolocy.WhenShouldTakeSnapshot(() => SaveSnapshot(snapshotSerializer.Serialize(getSnapshotData())));
                Recover<SnapshotOffer>(offer => onSnapshotLoaded(snapshotSerializer.Deserialize<TSnapshot>(offer.Snapshot)));
            }
        }


        public override string PersistenceId => GetPersistId();


        protected abstract string GetPersistId();
        private SnapshotPersistPolocy _snapshotPersistPolocy;
    }
}

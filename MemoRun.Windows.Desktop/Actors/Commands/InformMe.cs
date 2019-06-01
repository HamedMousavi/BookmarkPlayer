namespace MemoRun.Windows.Desktop.Actors.Commands
{

    public class SendEvents
    {

        public object Subscriber { get; }
        public SynchronizationPolocy SyncPolocy { get; private set; }


        public SendEvents(object me, SynchronizationPolocy syncPolocy = SynchronizationPolocy.IgnoreArchivedMessages)
        {
            Subscriber = me;
            SyncPolocy = syncPolocy;
        }


        internal static SendEvents To(object subscriber)
        {
            return new SendEvents(subscriber);
        }


        internal SendEvents IncludeArchivedEvents()
        {
            SyncPolocy = SynchronizationPolocy.SendArchivedMessages;
            return this;
        }
    }


    public enum SynchronizationPolocy
    {
        IgnoreArchivedMessages,
        SendArchivedMessages
    }
}
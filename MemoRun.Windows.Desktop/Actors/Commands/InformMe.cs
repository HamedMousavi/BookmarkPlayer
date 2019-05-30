namespace MemoRun.Windows.Desktop.Actors.Commands
{

    public class SendEventsTo
    {

        public SendEventsTo(object me)
        {
            Subscriber = me;
        }

        public object Subscriber { get; }
    }}

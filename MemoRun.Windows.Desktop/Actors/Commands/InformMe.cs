namespace MemoRun.Windows.Desktop.Actors.Commands
{

    public class Inform
    {

        public Inform(object me)
        {
            Subscriber = me;
        }

        public object Subscriber { get; }
    }}

namespace MemoRun.Windows.Desktop.Actors.Events
{
    public class Added<T>
    {
        public Added(T item) { Item = item; }

        public T Item { get; }
    }
}

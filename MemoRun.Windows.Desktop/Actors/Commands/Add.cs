namespace MemoRun.Windows.Desktop.Actors.Commands
{
    public class Add<T>
    {
        public Add(T item) { Item = item; }

        public T Item { get; }
    }
}

namespace MemoRun.Windows.Desktop.Resources
{
    public class Library
    {
        public Library(string title)
        {
            Title = title;
        }

        public static implicit operator Library(string title)
        {
            return new Library(title);
        }


        public string Title { get; }
    }
}

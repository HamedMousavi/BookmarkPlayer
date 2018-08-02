using Lib.Composables.Abstract;


namespace Lib.Composables
{

    public class Notifiable : Executable
    {

        public override void Add(IComposable composable)
        {
            base.Add(composable);
            Notify(new Added(composable));
        }


        public override void AddBookmarker(IComposable bookmarker)
        {
            base.AddBookmarker(bookmarker);
            Notify(new AddedBookmarker(bookmarker));
        }
    }
}

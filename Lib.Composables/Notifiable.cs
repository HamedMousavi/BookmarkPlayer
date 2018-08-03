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


        protected override void Delete(IComposable composable)
        {
            base.Delete(composable);
            Notify(new Deleted(composable));
        }


        public override void AddBookmarker(IComposable bookmarker)
        {
            base.AddBookmarker(bookmarker);
            Notify(new AddedBookmarker(bookmarker));
        }


        public override void AddTag(Tag tag)
        {
            base.AddTag(tag);
            Notify(new AddedTag(tag));
        }
    }
}

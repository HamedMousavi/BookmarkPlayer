namespace BookmarkPlayer.Domain
{
    public interface ITaggable : IComposable
    {
        void AddTag(Tag tag);
    }
}

namespace BookmarkPlayer.Domain.Abstract
{
    public interface ITaggable : IComposable
    {
        void AddTag(Tag tag);
    }
}

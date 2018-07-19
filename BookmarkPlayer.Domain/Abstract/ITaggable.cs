namespace BookmarkPlayer.Domain
{
    public interface ITaggable : IComposable, ISearchable<TextSearchMatch<Tag>, string>
    {
        void AddTag(Tag tag);
    }
}

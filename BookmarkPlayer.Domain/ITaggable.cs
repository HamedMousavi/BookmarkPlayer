namespace BookmarkPlayer.Domain
{
    public interface ITaggable : ISearchable<TextSearchMatch<Tag>, string>
    {
        void AddTag(Tag tag);
    }
}

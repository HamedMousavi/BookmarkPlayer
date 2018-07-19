namespace BookmarkPlayer.Domain
{
    public interface IBookmarkable : IComposable
    {
        void ToggleBookmark(IBookmarkable child);
        bool IsBookmarked(IBookmarkable child);

        void AddBookmarker(IBookmarkable bookmarker);
        void RemoveBookmarker(IBookmarkable bookmarkable);
        bool IsBookmarkedIn(IBookmarkable bookmarker);
    }
}

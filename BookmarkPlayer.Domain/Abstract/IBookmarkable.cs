namespace BookmarkPlayer.Domain
{
    public interface IBookmarkable : IComposable
    {
        void ToggleBookmark(IBookmarkable child);
        bool IsBookmarked(IComposable child);

        void AddBookmarker(IComposable bookmarker);
        void RemoveBookmarker(IComposable bookmarkable);
        bool IsBookmarkedIn(IComposable bookmarker);
    }
}

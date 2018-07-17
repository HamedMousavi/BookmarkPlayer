using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public class Bookmarkable : Selectable, IBookmarkable
    {

        public void ToggleBookmark(IBookmarkable child)
        {
            if (_bookmark == child)
            {
                _bookmark = null;
                child.RemoveBookmarker(this);
            }
            else
            {
                _bookmark = child;
                child.AddBookmarker(this);
            }
        }


        public bool IsBookmarked(IBookmarkable child)
        {
            return child != null &&
                Contains(child) &&
                _bookmark == child;
        }


        public bool IsBookmarkedIn(IBookmarkable bookmarker)
        {
            return _bookmarkers.Contains(bookmarker);
        }


        public void AddBookmarker(IBookmarkable bookmarker)
        {
            if (_bookmarkers == null) _bookmarkers = new HashSet<IBookmarkable>();
            if (!_bookmarkers.Contains(bookmarker)) _bookmarkers.Add(bookmarker);
        }


        public void RemoveBookmarker(IBookmarkable bookmarker)
        {
            if (_bookmarkers == null) throw new ComposableNullException(nameof(bookmarker));
            if (_bookmarkers.Contains(bookmarker)) _bookmarkers.Remove(bookmarker);
        }


        private IBookmarkable _bookmark;
        private ICollection<IBookmarkable> _bookmarkers;
    }
}

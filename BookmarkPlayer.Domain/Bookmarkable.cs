using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public class Bookmarkable : Selectable, IBookmarkable
    {

        public virtual void ToggleBookmark(IBookmarkable child)
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


        public virtual bool IsBookmarked(IBookmarkable child)
        {
            return child != null &&
                Contains(child) &&
                _bookmark == child;
        }


        public virtual bool IsBookmarkedIn(IBookmarkable bookmarker)
        {
            return _bookmarkers.Contains(bookmarker);
        }


        public virtual void AddBookmarker(IBookmarkable bookmarker)
        {
            if (_bookmarkers == null) _bookmarkers = new HashSet<IBookmarkable>();
            if (!_bookmarkers.Contains(bookmarker)) _bookmarkers.Add(bookmarker);
        }


        public virtual void RemoveBookmarker(IBookmarkable bookmarker)
        {
            if (_bookmarkers == null) throw new ComposableNullException(nameof(bookmarker));
            if (_bookmarkers.Contains(bookmarker)) _bookmarkers.Remove(bookmarker);
        }


        protected IBookmarkable _bookmark;
        protected ICollection<IBookmarkable> _bookmarkers;
    }
}

using BookmarkPlayer.Domain.Abstract;
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


        public virtual bool IsBookmarked(IComposable child)
        {
            return child != null &&
                Contains(child) &&
                _bookmark == child;
        }


        public virtual bool IsBookmarkedIn(IComposable bookmarker)
        {
            return _bookmarkers.Contains(bookmarker);
        }


        public virtual void AddBookmarker(IComposable bookmarker)
        {
            if (_bookmarkers == null) _bookmarkers = new HashSet<IComposable>();
            if (!_bookmarkers.Contains(bookmarker)) _bookmarkers.Add(bookmarker);
        }


        public virtual void RemoveBookmarker(IComposable bookmarker)
        {
            if (_bookmarkers == null) throw new ComposableNullException(nameof(bookmarker));
            if (_bookmarkers.Contains(bookmarker)) _bookmarkers.Remove(bookmarker);
        }


        protected IComposable _bookmark;
        protected ICollection<IComposable> _bookmarkers;
    }
}

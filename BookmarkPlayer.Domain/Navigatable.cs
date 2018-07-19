using BookmarkPlayer.Domain.Abstract;
using System;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class Navigatable : Taggable, INavigatable
    {

        private IComposable _active;


        public IComposable CurrentItem()
        {
            return _active;
        }


        public void MoveFirst()
        {
            if (_children == null || !_children.Any())
                throw new NavigationListEmptyException();

            _active = _children.First();
        }


        public void MoveForward()
        {
            if (_children == null || !_children.Any())
                throw new NavigationListEmptyException();

            if (_active == null)
                throw new NavigationCurrentItemNullException();

            if (_active == _children.Last()) return;

            _active = FindNext(_active);
        }


        public void MoveBackward()
        {
            if (_children == null || !_children.Any())
                throw new NavigationListEmptyException();

            if (_active == null)
                throw new NavigationCurrentItemNullException();

            if (_active == _children.First()) return;

            _active = FindPrevious(_active);
        }


        // todo: Use iteration: this algorithm is not scalable! :-/
        private IComposable FindNext(IComposable item)
        {
            var found = false;
            foreach (var child in _children)
            {
                if (found) return child;
                if (child == _active) found = true;
            }

            return item;
        }


        // todo: Uses iteration: this algorithm is not scalable! :-/
        private IComposable FindPrevious(IComposable item)
        {
            var previous = item;
            foreach (var child in _children)
            {
                if (child == _active) return previous;
                previous = child;
            }

            return item;
        }


        public void MoveLast()
        {
            if (_children == null || !_children.Any())
                throw new NavigationListEmptyException();

            _active = _children.Last();
        }


        public void MoveTo(IComposable item)
        {
            if (_children == null || !_children.Any())
                throw new NavigationListEmptyException();

            if (!Contains(item))
                throw new NotInComposableListException(nameof(item));

            _active = item;
        }

    }


    public class NavigationException : Exception
    {
        public NavigationException(string message) : base(message) { }
        public NavigationException() : base() { }
    }

    public class NavigationCurrentItemNullException : NavigationException
    {
        public NavigationCurrentItemNullException(): base("There is no origin to move from. Set current item first before starting navigation.") { }
    }

    public class NavigationListEmptyException : NavigationException
    {
        public NavigationListEmptyException() : 
            base("There is no children in this object to navigate among them! Add some children first and then try navigating!") { }
    }
}

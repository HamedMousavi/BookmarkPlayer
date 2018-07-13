using System;
using System.Collections;
using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public class Composable : IEnumerable<Composable>, IComparable<Composable>
    {

        public string Title { get; }


        public Composable(string title)
        {
            Title = title;
        }


        public void Add(Composable media)
        {
            if (_children == null) _children = new SortedSet<Composable>();
            _children.Add(media);
        }


        public int Count()
        {
            return _children == null ? 0 : _children.Count;
        }


        public IEnumerator<Composable> GetEnumerator()
        {
            return _children?.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children?.GetEnumerator();
        }


        public int CompareTo(Composable other)
        {
            return string.Compare(
                Title,
                other.Title,
                StringComparison.InvariantCultureIgnoreCase);
        }


        private SortedSet<Composable> _children;
    }
}

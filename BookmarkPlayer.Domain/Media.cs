using System.Collections;
using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public class Media : IEnumerable<Media>
    {

        public string Title { get; }


        public Media(string title)
        {
            Title = title;
        }


        public void Add(Media media)
        {
            if (_children == null) _children = new SortedSet<Media>();
            _children.Add(media);
        }


        public IEnumerator<Media> GetEnumerator()
        {
            return _children?.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children?.GetEnumerator();
        }


        private SortedSet<Media> _children;
    }
}

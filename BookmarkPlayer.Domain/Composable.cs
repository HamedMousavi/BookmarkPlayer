using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class Composable : IEnumerable<Composable>
    {

        public string Title { get; }
        public DateTime AddDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }


        public Composable(string title)
        {
            Title = title;
        }


        public virtual void Add(Composable composable)
        {
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (_children == null) _children = new HashSet<Composable>();

            composable.AddDate = DateTime.UtcNow;
            _children.Add(composable);
        }


        //public void Remove(Composable media)
        //{
        //    if (_children == null) throw new ComposableListEmptyException();
        //    _children.Remove(media);
        //}


        public virtual void Remove(Composable composable)
        {
            if (_children == null) throw new ComposableListEmptyException();
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (!_children.Contains(composable)) throw new NotInComposableListException(composable.Title);

            composable.DeleteDate = DateTime.UtcNow;
        }


        public virtual int Count()
        {
            return _children == null ? 0 : _children.Count(IsActive);
        }




        public IEnumerator<Composable> GetEnumerator()
        {
            return _children?.Where(IsActive).GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children?.Where(IsActive).GetEnumerator();
        }


        public override string ToString()
        {
            return $"{Title} [{AddDate}]";
        }


        protected virtual bool IsActive(Composable composable)
        {
            return composable.DeleteDate == null;
        }


        protected HashSet<Composable> _children;
    }


    public class ComposableException : Exception { }
    public class ComposableListEmptyException : ComposableException { }
    public class InvalidComposableException : ComposableException
    {
        public InvalidComposableException(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
    public class ComposableNullException : InvalidComposableException
    {
        public ComposableNullException(string name) : base(name) { }
    }
    public class NotInComposableListException : InvalidComposableException
    {
        public NotInComposableListException(string name) : base(name) { }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class Composable : IComposable
    {

        public DateTime? AddedDate()
        {
            return _addedDate;
        }


        public DateTime? DeletedDate()
        {
            return _deletedDate;
        }


        public virtual void Add(IComposable composable)
        {
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (_children == null) _children = new HashSet<IComposable>();
            if (_children.Contains(composable)) throw new ComposableAlreadyExistsException(nameof(composable));

            composable.AddTo(_children);
        }


        protected virtual void Delete(IComposable composable)
        {
            if (_children == null) throw new ComposableListEmptyException();
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (!_children.Contains(composable)) throw new NotInComposableListException(composable.ToString());

            composable.RemoveFrom(_children);
        }


        protected virtual int GetCount()
        {
            return _children == null ? 0 : _children.Count(IsActive);
        }


        public void AddTo(ICollection<IComposable> collection)
        {
            if (collection == null) throw new ComposableListEmptyException();
            _addedDate = DateTime.UtcNow;
            collection.Add(this);
        }


        public void RemoveFrom(ICollection<IComposable> collection)
        {
            _deletedDate = DateTime.UtcNow;
        }


        public IEnumerator<IComposable> GetEnumerator()
        {
            return _children == null
                ? Enumerable.Empty<IComposable>().GetEnumerator()
                : _children.Where(IsActive).GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _children == null
                ? Enumerable.Empty<IComposable>().GetEnumerator()
                : _children.Where(IsActive).GetEnumerator();
        }


        protected virtual bool IsActive(IComposable composable)
        {
            return composable.DeletedDate() == null;
        }


        public bool Contains(IComposable composable)
        {
            return _children != null && _children.Contains(composable);
        }


        public void Clear()
        {
            _children.Clear();
        }


        public void CopyTo(IComposable[] array, int arrayIndex)
        {
            if (_children == null) throw new ComposableListEmptyException();
            _children.CopyTo(array, arrayIndex);
        }


        public bool Remove(IComposable composable)
        {
            Delete(composable);
            return true;
        }


        public int Count => GetCount();
        public bool IsReadOnly => false;


        protected ICollection<IComposable> _children;
        protected DateTime? _addedDate;
        protected DateTime? _deletedDate;
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
    public class ComposableAlreadyExistsException : InvalidComposableException
    {
        public ComposableAlreadyExistsException(string name) : base(name) { }
    }
    public class NotInComposableListException : InvalidComposableException
    {
        public NotInComposableListException(string name) : base(name) { }
    }
    public class ComposableNotSupportedException : InvalidComposableException
    {
        public ComposableNotSupportedException(string name) : base(name) { }
    }
}

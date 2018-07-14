using System;
using System.Collections;
using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public class Selectable : IComposable
    {

        public Selectable(IComposable composable)
        {
            _composable = composable;
        }


        public Selectable Selected()
        {
            return _selected;
        }


        public bool IsSelected()
        {
            return _isSelected;
        }


        public virtual void Select(Selectable selectable)
        {
            if (selectable == null) throw new ComposableNullException(nameof(selectable));
            if (selectable._composable == null) throw new ComposableNullException(nameof(selectable._composable));
            if (!_composable.Contains(selectable._composable)) throw new NotInComposableListException(selectable.Title());

            if (_selected != null) _selected._isSelected = false;

            _selected = selectable;
            _selected._isSelected = true;
        }


        public virtual void Deselect(Selectable composable)
        {
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (!_composable.Contains(composable._composable)) throw new NotInComposableListException(composable.Title());
            if (_selected != composable) throw new ComposableNotSelectedException();

            Deselect();
        }


        public virtual void Deselect()
        {
            if (_selected == null) return;

            _selected._isSelected = false;
            _selected = null;
        }


        private Selectable _selected;
        private bool _isSelected;
        private readonly IComposable _composable;


        public int Count => _composable.Count;
        public bool IsReadOnly => _composable.IsReadOnly;


        public void Add(IComposable item)
        {
            _composable.Add(item);
        }


        public DateTime? AddedDate()
        {
            return _composable.AddedDate();
        }


        public void AddTo(ICollection<IComposable> collection)
        {
            _composable.AddTo(collection);
        }


        public void Clear()
        {
            _composable.Clear();
        }


        public bool Contains(IComposable item)
        {
            return _composable.Contains(item);
        }


        public void CopyTo(IComposable[] array, int arrayIndex)
        {
            _composable.CopyTo(array, arrayIndex);
        }


        public DateTime? DeletedDate()
        {
            return _composable.DeletedDate();
        }


        public IEnumerator<IComposable> GetEnumerator()
        {
            return _composable.GetEnumerator();
        }


        public bool Remove(IComposable item)
        {
            return _composable.Remove(item);
        }


        public void RemoveFrom(ICollection<IComposable> collection)
        {
            _composable.RemoveFrom(collection);
        }


        public string Title()
        {
            return _composable.Title();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return _composable.GetEnumerator();
        }
    }

    public class ComposableNotSelectedException : ComposableException { }
}

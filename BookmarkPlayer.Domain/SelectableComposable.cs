namespace BookmarkPlayer.Domain
{

    public class SelectableComposable : Composable
    {

        public SelectableComposable Selected { get; protected set; }
        public bool IsSelected { get; protected set; }


        public SelectableComposable(string title) : base(title)
        {

        }


        public virtual void Select(SelectableComposable composable)
        {
            if (_children == null) throw new ComposableListEmptyException();
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (!_children.Contains(composable)) throw new NotInComposableListException(composable.Title);

            if (Selected != null) Selected.IsSelected = false;

            composable.IsSelected = true;
            Selected = composable;
        }


        public virtual void Deselect(Composable composable)
        {
            if (_children == null) throw new ComposableListEmptyException();
            if (composable == null) throw new ComposableNullException(nameof(composable));
            if (!_children.Contains(composable)) throw new NotInComposableListException(composable.Title);
            if (Selected != composable) throw new ComposableNotSelectedException();

            Deselect();
        }


        public virtual void Deselect()
        {
            if (Selected == null) return;

            Selected.IsSelected = false;
            Selected = null;
        }
    }

    public class ComposableNotSelectedException : ComposableException { }
}

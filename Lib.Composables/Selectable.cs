using Lib.Composables.Abstract;
using System.Collections.Generic;
using System.Linq;


namespace Lib.Composables
{

    public class Selectable : Composable, ISelectable
    {

        public IEnumerable<ISelectable> Selected()
        {
            return this.OfType<ISelectable>().Where(s => s.IsSelected());
        }


        public virtual bool IsSelected(ISelectable selectable)
        {
            return selectable != null &&
                selectable.IsSelected() &&
                Contains(selectable);
        }


        public virtual void Select(ISelectable selectable)
        {
            if (selectable == null) throw new ComposableNullException(nameof(selectable));
            if (!Contains(selectable)) throw new NotInComposableListException(selectable.ToString());

            if (Contains(selectable) && selectable.IsSelected()) throw new ComposableAlreadyExistsException(nameof(selectable));

            selectable.Select();
        }


        public virtual void Deselect(ISelectable selectable)
        {
            if (selectable == null) throw new ComposableNullException(nameof(selectable));
            if (!Contains(selectable)) throw new NotInComposableListException(selectable.ToString());

            selectable.Deselect();
        }


        public virtual void Select()
        {
            _isSelected = true;
        }


        public virtual void Deselect()
        {
            _isSelected = false;
        }


        public virtual bool IsSelected()
        {
            return _isSelected == true;
        }


        private bool _isSelected;
    }

    public class ComposableNotSelectedException : ComposableException { }
}

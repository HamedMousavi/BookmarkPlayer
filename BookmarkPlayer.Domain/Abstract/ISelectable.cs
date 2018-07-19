using System.Collections.Generic;


namespace BookmarkPlayer.Domain
{

    public interface ISelectable : IComposable
    {
        IEnumerable<ISelectable> Selected();
        bool IsSelected(ISelectable selectable);
        void Deselect(ISelectable selectable);
        void Select(ISelectable selectable);

        bool IsSelected();
        void Select();
        void Deselect();
    }
}
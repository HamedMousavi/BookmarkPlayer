namespace BookmarkPlayer.Domain
{
    public interface ISelectable : IComposable
    {
        ISelectable Selected();

        void Deselect();
        void Deselect(ISelectable composable);
        bool IsSelected();
        void Select(ISelectable selectable);
    }
}
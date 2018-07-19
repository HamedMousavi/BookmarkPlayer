namespace BookmarkPlayer.Domain.Abstract
{
    public interface INavigatable : IComposable
    {
        IComposable CurrentItem();
        int CurrentItemIndex();

        void MoveTo(IComposable item);
        void MoveFirst();
        void MoveLast();
        void MoveForward();
        void MoveBackward();
        //int ProgressPercentage(); 
    }
}

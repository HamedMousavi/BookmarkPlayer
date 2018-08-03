using Lib.Composables.Abstract;


namespace BookmarkPlayer.Domain
{

    public interface IFolder : 
        ISearchable<string>
        , ISearcher<string>
        , IExecutable
        , IProgressable
        , INavigatable
        , ITaggable
        , IBookmarkable
        , ISelectable
        , IComposable
        , IComposableObservable
    {
    }
}

using System.Collections.Generic;


namespace BookmarkPlayer.Domain.Abstract
{
    public interface ISearchable<T>
    {
        IEnumerable<ISearchResult<T>> Search(ISearchEngine<T> searchEngine, T searchTerm);
    }
}

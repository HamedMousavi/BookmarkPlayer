using System.Collections.Generic;


namespace Lib.Composables.Abstract
{
    public interface ISearchable<T>
    {
        IEnumerable<ISearchResult<T>> Search(ISearchEngine<T> searchEngine, T searchTerm);
    }
}

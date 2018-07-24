using System.Collections.Generic;

namespace Lib.Composables.Abstract
{
    public interface ISearchEngine<T>
    {
        IEnumerable<ISearchResult<T>> Search(T term);
        IEnumerable<ISearchResult<T>> Search(T term, IEnumerable<ISearcher<T>> searchables);
    }


    public interface ISearchResult<T>
    {
        T SearchPhrase { get; }
        ISearcher<T> Found { get; }
    }


    public interface ISearcher<in T>
    {
        bool Contains(T term);
    }
}

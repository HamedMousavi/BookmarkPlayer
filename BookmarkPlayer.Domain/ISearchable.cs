using System.Collections.Generic;

namespace BookmarkPlayer.Domain
{
    public interface ISearchable<TOut, TIn>
    {
        IEnumerable<TOut> Search(TIn searchPhrase);
    }
}

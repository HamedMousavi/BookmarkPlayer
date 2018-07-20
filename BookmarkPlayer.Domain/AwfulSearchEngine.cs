using BookmarkPlayer.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class AwfulSearchEngine : ISearchEngine<string>
    {

        private IEnumerable<ISearcher<string>> _searchers;


        public AwfulSearchEngine()
        {

        }


        public AwfulSearchEngine(IEnumerable<ISearcher<string>> searchables)
        {
            _searchers = searchables;
        }


        public IEnumerable<ISearchResult<string>> Search(string searchPhrase)
        {
            return Search(searchPhrase, _searchers);
        }


        public IEnumerable<ISearchResult<string>> Search(string searchPhrase, IEnumerable<ISearcher<string>> searchers)
        {
            var words = searchPhrase.Split(' ')
                .Where(s => !string.IsNullOrWhiteSpace(s));

            var result = new List<ISearchResult<string>>();
            result.AddRange(
                searchers
                .Where(s => s != null && s.Contains(searchPhrase))
                .Select(t => new TextSearchResult(t, searchPhrase, 100))
                .OfType<ISearchResult<string>>());

            if (!result.Any())
            {
                foreach (var word in words)
                    result.AddRange(
                        searchers
                        .Where(s => s.Contains(word))
                    .Select(t => new TextSearchResult(t, word, 50))
                    .OfType<ISearchResult<string>>());
            }

            return result.OfType<ISearchResult<string>>();
        }
    }
}

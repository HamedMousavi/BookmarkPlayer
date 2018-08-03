using Lib.Composables.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lib.Composables
{

    public abstract class TextSearchable : Notifiable, ISearchable<string>
    {

        public IEnumerable<ISearchResult<string>> Search(ISearchEngine<string> searchEngine, string searchTerm)
        {
            ClearResults();

            AddResults(SearchChildren(searchEngine, searchTerm));
            AddResults(SearchParents(searchEngine, searchTerm));

            return _searchResults;
        }


        private void ClearResults()
        {
            if (_searchResults == null) _searchResults = new List<ISearchResult<string>>();
            else _searchResults.Clear();
        }


        private void AddResults(IEnumerable<ISearchResult<string>> results)
        {
            if (results == null || !results.Any()) return;

            _searchResults.AddRange(results);
        }


        private IEnumerable<ISearchResult<string>> SearchChildren(ISearchEngine<string> searchEngine, string searchTerm)
        {
            return _children
                ?.OfType<ISearchable<string>>()
                ?.Distinct()
                ?.SelectMany(c => c.Search(searchEngine, searchTerm));
        }


        private IEnumerable<ISearchResult<string>> SearchParents(ISearchEngine<string> searchEngine, string searchTerm)
        {
            CreateSearchers();
            return searchEngine.Search(searchTerm, _searchers);
        }


        private void CreateSearchers()
        {
            if (_searchers == null)
                _searchers = new List<ISearcher<string>>();
            else _searchers.Clear();

            _searchers.AddRange(GetTextSearchers().ToList());
        }


        private List<ISearcher<string>> _searchers;
        private List<ISearchResult<string>> _searchResults;


        protected abstract TextSearcherList GetTextSearchers();
    }


    public class TextSearcher
    {

        private ICollection<string> _searchables;


        public TextSearcher(params string[] searchables)
        {
            _searchables = new HashSet<string>(searchables);
        }


        public bool Search(string term)
        {
            var searchables = _searchables
                .Where(s => !string.IsNullOrEmpty(s))
                .Distinct();

            // todo: invariant culture
            return searchables.Any(s => s.Contains(term) || term.Contains(s));
        }
    }


    public class TextSearcherList
    {

        private List<ISearcher<string>> _searchers;


        public TextSearcherList()
        {
            _searchers = new List<ISearcher<string>>();
        }


        public TextSearcherList Add(ISearcher<string> searcher)
        {
            _searchers.Add(searcher);
            return this;
        }


        public TextSearcherList Add(IEnumerable<ISearcher<string>> searchers)
        {
            _searchers.AddRange(searchers);
            return this;
        }


        internal IEnumerable<ISearcher<string>> ToList()
        {
            return _searchers;
        }
    }
}

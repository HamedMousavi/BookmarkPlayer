using BookmarkPlayer.Domain.Abstract;
using System.Collections.Generic;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class Folder : Progressable, ISearchable<string>, ISearcher<string>
    {

        private readonly string _path;


        public Folder()
        { }


        public Folder(string title, string path)
        {
            _name = title;
            _path = path;
        }


        public bool Contains(string term)
        {
            var found = string.IsNullOrEmpty(_name)
                ? false
                : _name.Contains(term) || term.Contains(_name);

            found |= string.IsNullOrEmpty(_path)
                ? false
                : _path.Contains(term) || term.Contains(_path);

            return found;
        }


        public IEnumerable<ISearchResult<string>> Search(ISearchEngine<string> searchEngine, string searchTerm)
        {
            var searchers = new List<ISearcher<string>>();
            searchers.AddRange(Tags());
            searchers.Add(this);

            var results = new List<ISearchResult<string>>();
            var s = _children?.OfType<ISearchable<string>>().Distinct();
            if (s != null && s.Any())
            {
                var children = s.SelectMany(c => c.Search(searchEngine, searchTerm));
                results.AddRange(children);
            }

            results.AddRange(searchEngine.Search(searchTerm, searchers));
                        
            return results;
        }
    }
}

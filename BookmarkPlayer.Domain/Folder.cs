using Lib.Composables;
using Lib.Composables.Abstract;


namespace BookmarkPlayer.Domain
{

    public class Folder : TextSearchable, ISearcher<string>
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
            return new TextSearcher(_name, _path).Search(term);
        }


        protected override TextSearcherList GetTextSearchers()
        {
            return new TextSearcherList()
                .Add(Tags())
                .Add(this);
        }
    }
}

using Lib.Composables;


namespace BookmarkPlayer.Domain
{

    public class Folder : TextSearchable, IFolder
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

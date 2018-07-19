namespace BookmarkPlayer.Domain
{

    public struct TextSearchResult : ISearchResult<string>
    {

        public TextSearchResult(ISearcher<string> found, string word)
        {
            Found = found;
            SearchPhrase = word;
        }


        public string SearchPhrase { get; }
        public ISearcher<string> Found { get; }

        public override string ToString()
        {
            return $"Result for '{SearchPhrase}': {Found}";
        }
    }
}

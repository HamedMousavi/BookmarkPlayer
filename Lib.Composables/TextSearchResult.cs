using Lib.Composables.Abstract;


namespace Lib.Composables
{

    public struct TextSearchResult : ISearchResult<string>
    {

        public TextSearchResult(ISearcher<string> found, string word, double score)
        {
            Found = found;
            SearchPhrase = word;
            Score = score;
        }


        public string SearchPhrase { get; }
        public double Score { get; }
        public ISearcher<string> Found { get; }

        public override string ToString()
        {
            return $"Result for '{SearchPhrase}': {Found}";
        }
    }
}

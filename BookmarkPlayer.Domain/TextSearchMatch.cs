namespace BookmarkPlayer.Domain
{
    public struct TextSearchMatch<T>
    {
        public string SearchPhrase { get; set; }
        public T Found { get; set; }
    }
}

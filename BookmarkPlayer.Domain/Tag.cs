using System;


namespace BookmarkPlayer.Domain
{

    public class Tag : ISearcher<string>
    {

        private string _label;


        public Tag(string label)
        {
            _label = label;
        }


        public static implicit operator Tag(string label)
        {
            return new Tag(label);
        }


        public string Label()
        {
            return _label;
        }


        public bool IsEqual(Tag tag)
        {
            return string.Equals(
                tag.Label(),
                this.Label(),
                StringComparison.InvariantCultureIgnoreCase);
        }


        public override string ToString()
        {
            return Label();
        }


        public bool Contains(string searchPhrase)
        {
            // todo: invariant culture
            return Label().Contains(searchPhrase) ||
                searchPhrase.Contains(Label());
        }
    }
}

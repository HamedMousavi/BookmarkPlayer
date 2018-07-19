using System;


namespace BookmarkPlayer.Domain
{

    public class Tag
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


        public bool IsLike(string searchPhrase)
        {
            return Label().Contains(searchPhrase) ||
                searchPhrase.Contains(Label());
        }


        public override string ToString()
        {
            return Label();
        }
    }
}

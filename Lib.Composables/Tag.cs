using Lib.Composables.Abstract;
using System;


namespace Lib.Composables
{

    public class Tag : ISearcher<string>
    {

        private readonly string _label;


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
            return new TextSearcher(Label()).Search(searchPhrase);
        }
    }
}

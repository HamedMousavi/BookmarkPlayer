using System.Collections.Generic;
using System.Linq;


namespace BookmarkPlayer.Domain
{

    public class Taggable : Bookmarkable, ITaggable
    {

        public void AddTag(Tag tag)
        {
            if (!HasTag(tag))
            {
                if (_tags == null) _tags = new HashSet<Tag>();
                _tags.Add(tag);
            }
        }


        public bool HasTag(Tag tag)
        {
            return _tags == null 
                ? false 
                : _tags.Any(t => t.IsEqual(tag));
        }


        public IEnumerable<Tag> Tags()
        {
            return _tags ?? (_tags = new HashSet<Tag>());
        }


        private ICollection<Tag> _tags;
    }
}

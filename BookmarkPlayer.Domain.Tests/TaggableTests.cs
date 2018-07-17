using System.Linq;
using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class TaggableTests
    {

        [Fact]
        public void TaggableShouldAllowAddingTags()
        {
            var taggable = new Taggable();
            taggable.AddTag("C#");
            taggable.AddTag("Training");
            taggable.AddTag("Design");

            Assert.True(taggable.HasTag("C#"));
            Assert.True(taggable.HasTag("Design"));
            Assert.False(taggable.HasTag("C++"));
        }


        [Fact]
        public void TaggableShouldGiveAllTags()
        {
            var taggable = new Taggable();
            Assert.Empty(taggable.Tags());

            taggable.AddTag("C#");
            taggable.AddTag("Training");
            taggable.AddTag("Design");

            Assert.Equal(3, taggable.Tags().Count());
        }
    }
}

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


        [Fact]
        public void TaggableShouldBeSearchable()
        {
            var taggable = new Taggable();
            var designPatterns = new Tag("Design Patterns");
            var training = new Tag("Training");

            taggable.AddTag("C#");
            taggable.AddTag(training);
            taggable.AddTag(designPatterns);

            var result = taggable.Search("sign");
            Assert.Single(result);
            Assert.Equal(designPatterns, result.First().Result);

            result = taggable.Search("n");
            Assert.Equal(2, result.Count());
            Assert.Equal(training, result.First().Result);
            Assert.Equal(designPatterns, result.Last().Result);
        }
    }
}

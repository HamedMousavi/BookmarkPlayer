using System.Linq;
using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class SearchTests
    {

        [Fact]
        public void TaggableShouldBeSearchable()
        {
            var taggable = new Taggable();
            var designPatterns = new Tag("Design Patterns");
            var training = new Tag("Training");

            taggable.AddTag("C#");
            taggable.AddTag(training);
            taggable.AddTag(designPatterns);

            var searchEngine = new AwfulSearchEngine(taggable.Tags());

            var result = searchEngine.Search("sign");
            Assert.Single(result);
            Assert.True(designPatterns == result.First().Found);

            result = searchEngine.Search("n");
            Assert.Equal(2, result.Count());
            Assert.True(training == result.First().Found);
            Assert.True(designPatterns == result.Last().Found);
        }
    }
}

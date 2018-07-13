using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class MediaListTests
    {

        [Fact]
        public void MediaShouldBeTaggable()
        {
            var trainings = new Media("Trainings")
            {
                new Media("Akka .Net"),
                new Media("Advanced TDD")
            };

            var series = new Media("Series")
            {
                new Media("Friends"),
                new Media("Family Guy")
            };
        }
    }
}

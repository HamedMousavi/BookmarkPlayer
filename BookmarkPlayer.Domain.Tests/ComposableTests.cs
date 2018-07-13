using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class ComposableTests
    {

        [Fact]
        public void ComposableShouldReportItsChildrenCount()
        {
            var trainings = new Composable("Trainings");
            Assert.Equal(0, trainings.Count());

            trainings.Add(new Composable("Akka .Net"));
            Assert.Equal(1, trainings.Count());

            trainings.Add(new Composable("Advanced TDD"));
            Assert.Equal(2, trainings.Count());

            var series = new Composable("Series")
            {
                new Composable("Friends"),
                new Composable("Family Guy"),
                new Composable("IT Crowd"),
            };

            Assert.Equal(3, series.Count());
        }
    }
}

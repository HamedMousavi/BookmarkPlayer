using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class ComposableTests
    {

        [Fact]
        public void ComposableShouldReportNumberOfAddedChildren()
        {
            var trainings = new Composable("Trainings");
            Assert.Equal(0, trainings.Count());

            trainings.Add(new Composable("Akka .Net"));
            Assert.Equal(1, trainings.Count());

            trainings.Add(new Composable("Advanced TDD"));
            Assert.Equal(2, trainings.Count());

            var comedies = new Composable("Series")
            {
                new Composable("Friends"),
                new Composable("Family Guy"),
                new Composable("IT Crowd"),
            };

            Assert.Equal(3, comedies.Count());
        }


        [Fact]
        public void ComposableShouldConsiderNumberOfRemovedChildren()
        {
            var courses = new Composable("Courses");
            var course = new Composable(".Net Core");
            courses.Add(course);
            courses.Remove(course);
            Assert.Equal(0, courses.Count());
        }


        [Fact]
        public void ComposableShouldAllowSelection()
        {
            var courses = new SelectableComposable("Courses");
            var course1 = new SelectableComposable(".Net Core");
            var course2 = new SelectableComposable("Akka .Net");

            courses.Add(course1);
            courses.Add(course2);

            courses.Select(course1);
            Assert.True(course1.IsSelected);
            Assert.False(course2.IsSelected);

            courses.Select(course2);
            Assert.True(course2.IsSelected);
            Assert.False(course1.IsSelected);

            courses.Deselect();
            Assert.False(course1.IsSelected);
            Assert.False(course2.IsSelected);
        }


    }
}

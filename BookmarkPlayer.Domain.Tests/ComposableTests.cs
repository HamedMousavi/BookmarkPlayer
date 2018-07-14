using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class ComposableTests
    {

        [Fact]
        public void ComposableShouldReportNumberOfAddedChildren()
        {
            var trainings = new Composable("Trainings");
            Assert.Empty(trainings);

            trainings.Add(new Composable("Akka .Net"));
            Assert.Single(trainings);

            trainings.Add(new Composable("Advanced TDD"));
            Assert.Equal(2, trainings.Count);

            var comedies = new Composable("Series")
            {
                new Composable("Friends"),
                new Composable("Family Guy"),
                new Composable("IT Crowd"),
            };

            Assert.Equal(3, comedies.Count);
        }


        [Fact]
        public void ComposableShouldConsiderNumberOfRemovedChildren()
        {
            var courses = new Composable("Courses");
            var course = new Composable(".Net Core");
            courses.Add(course);
            courses.Remove(course);
            Assert.Empty(courses);
        }


        [Fact]
        public void SelectableComposableShouldAllowSelectionAndDeselection()
        {
            var courses = new Selectable(new Composable("Courses"));
            var course1 = new Selectable(new Composable(".Net Core"));
            var course2 = new Selectable(new Composable("Akka .Net"));

            courses.Add(course1);
            courses.Add(course2);

            courses.Select(course1);
            Assert.True(course1.IsSelected());
            Assert.False(course2.IsSelected());

            courses.Select(course2);
            Assert.True(course2.IsSelected());
            Assert.False(course1.IsSelected());

            courses.Deselect();
            Assert.False(course1.IsSelected());
            Assert.False(course2.IsSelected());
        }


    }
}

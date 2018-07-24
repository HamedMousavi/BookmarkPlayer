using Xunit;


namespace Lib.Composables.Tests
{

    public class ProgressableTests
    {

        [Fact]
        public void ProgressableShouldShowProgress()
        {
            var parent = new Progressable();
            var child1 = new Composable("Akka .Net");
            var child2 = new Composable("C# TPL");
            var child3 = new Composable("Scalability");
            var child4 = new Composable("Advanced SQL");

            Assert.Equal(0, parent.Progress().Percentage());

            parent.Add(child1);
            parent.Add(child2);
            parent.Add(child3);
            parent.Add(child4);

            Assert.Equal(0, parent.Progress().Percentage());
            parent.MoveFirst();
            Assert.Equal(25, parent.Progress().Percentage());
            parent.MoveForward();
            Assert.Equal(50, parent.Progress().Percentage());
            parent.MoveForward();
            Assert.Equal(75, parent.Progress().Percentage());
            parent.MoveForward();
            Assert.Equal(100, parent.Progress().Percentage());
        }
    }
}

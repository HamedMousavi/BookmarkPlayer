using Xunit;


namespace Lib.Composables.Tests
{

    public class ComposableTests
    {

        [Fact]
        public void ComposableShouldReportCountOfAddedChildren()
        {
            var list = new Composable();
            Assert.Empty(list);

            list.Add(new Composable());
            Assert.Single(list);

            list.Add(new Composable());
            Assert.Equal(2, list.Count);

            var altList = new Composable
            {
                new Composable(),
                new Composable(),
                new Composable(),
            };

            Assert.Equal(3, altList.Count);
        }


        [Fact]
        public void ComposableShouldReportCountOfRemovedChildren()
        {
            var parent = new Composable();
            Assert.Empty(parent);

            var child1 = new Composable();
            Assert.Empty(child1);

            var child2 = new Composable();
            Assert.Empty(child2);

            var child3 = new Composable();
            Assert.Empty(child3);

            parent.Add(child1);
            Assert.Single(parent);

            parent.Add(child2);
            Assert.Equal(2, parent.Count);

            parent.Remove(child1);
            Assert.Single(parent);

            parent.Remove(child2);
            Assert.Empty(parent);
        }


        [Fact]
        public void ComposableShouldReportContainmentOfChildren()
        {
            var parent = new Composable();
            var child1 = new Composable();
            var child2 = new Composable();
            var child3 = new Composable();

            parent.Add(child1);
            parent.Add(child2);
            parent.Add(child3);
            child1.Add(child2);
            child1.Add(child3);
            child2.Add(child3);
            Assert.Equal(3, parent.Count);
            Assert.Equal(2, child1.Count);
            Assert.Single(child2);

            Assert.Contains(child1, parent);
            Assert.Contains(child2, parent);
            Assert.Contains(child3, parent);
            Assert.Contains(child2, child1);
            Assert.Contains(child3, child1);
            Assert.Contains(child3, child2);
        }


        [Fact]
        public void ComposableShouldReportCountAfterItWasCleared()
        {
            var parent = new Composable();
            var child1 = new Composable();
            var child2 = new Composable();
            var child3 = new Composable();

            parent.Add(child1);
            parent.Add(child2);
            parent.Add(child3);
            child1.Add(child2);
            child1.Add(child3);
            child2.Add(child3);
            Assert.Equal(3, parent.Count);
            Assert.Equal(2, child1.Count);
            Assert.Single(child2);

            parent.Clear();
            Assert.Empty(parent);

            child1.Clear();
            Assert.Empty(child1);

            child2.Clear();
            Assert.Empty(child2);
        }


        [Fact]
        public void ComposableShouldSetAddedDate()
        {
            var parent = new Composable();
            var child = new Composable();

            Assert.Null(child.AddedDate());
            Assert.Null(parent.AddedDate());

            parent.Add(child);

            Assert.NotNull(child.AddedDate());
            Assert.Null(parent.AddedDate());
        }


        [Fact]
        public void ComposableShouldSetDeletedDate()
        {
            var parent = new Composable();
            var child = new Composable();

            Assert.Null(child.DeletedDate());
            Assert.Null(parent.DeletedDate());

            parent.Add(child);

            Assert.Null(child.DeletedDate());
            Assert.Null(parent.DeletedDate());

            parent.Remove(child);

            Assert.NotNull(child.DeletedDate());
            Assert.Null(parent.DeletedDate());
        }
    }
}

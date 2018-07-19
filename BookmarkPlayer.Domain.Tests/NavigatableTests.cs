using BookmarkPlayer.Domain.Abstract;
using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class NavigatableTests
    {

        [Fact]
        public void NavigatableShouldBeInitiatedWithNull()
        {
            INavigatable list = new Navigatable();
            var child1 = new Composable();
            var child2 = new Composable();

            list.Add(child1);
            list.Add(child2);

            Assert.Null(list.CurrentItem());
            Assert.Throws<NavigationCurrentItemNullException>(() => list.MoveForward());
            Assert.Throws<NavigationCurrentItemNullException>(() => list.MoveBackward());
        }


        [Fact]
        public void NavigatableShouldThrowExceptionOnEmptyList()
        {
            INavigatable list = new Navigatable();
            Assert.Null(list.CurrentItem());
            Assert.Throws<NavigationListEmptyException>(() => list.MoveFirst());
            Assert.Throws<NavigationListEmptyException>(() => list.MoveLast());
            Assert.Throws<NavigationListEmptyException>(() => list.MoveForward());
            Assert.Throws<NavigationListEmptyException>(() => list.MoveBackward());
            Assert.Throws<NavigationListEmptyException>(() => list.MoveTo(null));
        }


        [Fact]
        public void NavigatableShouldMoveFirst()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable();
            var child2 = new Composable();

            parent.Add(child1);
            parent.Add(child2);

            Assert.Null(parent.CurrentItem());

            parent.MoveFirst();
            Assert.True(child1 == parent.CurrentItem());

            parent.MoveFirst();
            Assert.True(child1 == parent.CurrentItem());
        }


        [Fact]
        public void NavigatableShouldMoveLast()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable();
            var child2 = new Composable();

            parent.Add(child1);
            parent.Add(child2);

            Assert.Null(parent.CurrentItem());

            parent.MoveLast();
            Assert.True(child2 == parent.CurrentItem());

            parent.MoveLast();
            Assert.True(child2 == parent.CurrentItem());
        }


        [Fact]
        public void NavigatableShouldNotMoveToNonExistingItem()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable();
            var child2 = new Composable();

            Assert.Throws<NavigationListEmptyException>(() => parent.MoveTo(child1));

            parent.Add(child1);
            Assert.Throws<NotInComposableListException>(() => parent.MoveTo(child2));
        }


        [Fact]
        public void NavigatableShouldMoveToExistingItem()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable("child1");
            var child2 = new Composable("child2");
            parent.Add(child1);
            parent.Add(child2);

            parent.MoveFirst();
            Assert.True(child1 == parent.CurrentItem());

            parent.MoveTo(child1);
            Assert.True(child1 == parent.CurrentItem());

            parent.MoveTo(child2);
            Assert.True(child2 == parent.CurrentItem());
        }


        [Fact]
        public void NavigatableShouldMoveForward()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable("child1");
            var child2 = new Composable("child2");
            parent.Add(child1);
            parent.Add(child2);

            parent.MoveFirst();
            Assert.True(child1 == parent.CurrentItem());

            parent.MoveForward();
            Assert.True(child2 == parent.CurrentItem());

            parent.MoveForward();
            Assert.True(child2 == parent.CurrentItem());
        }


        [Fact]
        public void NavigatableShouldMoveBackward()
        {
            INavigatable parent = new Navigatable();
            var child1 = new Composable("child1");
            var child2 = new Composable("child2");
            parent.Add(child1);
            parent.Add(child2);

            parent.MoveTo(child2);
            parent.MoveBackward();
            Assert.True(child1 == parent.CurrentItem());
        }
    }
}

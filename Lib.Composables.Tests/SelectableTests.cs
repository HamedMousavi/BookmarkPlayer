using System.Linq;
using Xunit;


namespace Lib.Composables.Tests
{

    public class SelectableTests
    {

        [Fact]
        public void SelectableShouldBeSelectableAndDeselectable()
        {
            var selectable = new Selectable();
            selectable.Select();
            Assert.True(selectable.IsSelected());

            selectable.Deselect();
            Assert.False(selectable.IsSelected());
        }


        [Fact]
        public void SelectableChildShouldBeSelectableAndDeselectableViaParent()
        {
            var parent = new Selectable();
            var child1 = new Selectable();

            parent.Add(child1);
            parent.Select(child1);
            Assert.True(child1.IsSelected());
            Assert.True(parent.IsSelected(child1));

            parent.Deselect(child1);
            Assert.False(child1.IsSelected());
            Assert.False(parent.IsSelected(child1));
        }


        [Fact]
        public void SelectableChildShouldBeSelectableAndDeselectableDirectly()
        {
            var parent = new Selectable();
            var child1 = new Selectable();

            parent.Add(child1);
            child1.Select();
            Assert.True(child1.IsSelected());
            Assert.True(parent.IsSelected(child1));

            child1.Deselect();
            Assert.False(child1.IsSelected());
            Assert.False(parent.IsSelected(child1));
        }


        [Fact]
        public void SelectedChildShouldBeAvailable()
        {
            var parent = new Selectable();
            var child1 = new Selectable();

            parent.Add(child1);
            parent.Select(child1);
            Assert.NotNull(parent.Selected().SingleOrDefault(s => s == child1));

            parent.Deselect(child1);
            Assert.Null(parent.Selected().SingleOrDefault(s => s == child1));
        }


        [Fact]
        public void SelectableShouldSelectMultipleChildren()
        {
            var parent = new Selectable();
            var child1 = new Selectable();
            var child2 = new Selectable();

            parent.Add(child1);
            parent.Select(child1);
            parent.Add(child2);
            parent.Deselect(child1);
            parent.Select(child2);
            Assert.Equal(2, parent.Count);
            Assert.False(parent.IsSelected(child1));
            Assert.True(parent.IsSelected(child2));
            Assert.False(child1.IsSelected());
            Assert.True(child2.IsSelected());

            child1.Select();
            Assert.True(parent.IsSelected(child1));
            Assert.True(parent.IsSelected(child2));
            Assert.True(child1.IsSelected());
            Assert.True(child2.IsSelected());

            Assert.Equal(2, parent.Selected().Count());

            child1.Deselect();
            child2.Deselect();
            Assert.Empty(parent.Selected());
        }


        [Fact]
        public void SelectableShouldNotAllowSelectingNonExistingChild()
        {
            var parent = new Selectable();
            var child1 = new Selectable();
            var child2 = new Selectable();

            parent.Add(child1);
            Assert.Throws<NotInComposableListException>(() => parent.Select(child2));
            Assert.Throws<NotInComposableListException>(() => parent.Deselect(child2));
        }


        [Fact]
        public void SelectableShouldNotAllowSelectingNull()
        {
            var parent = new Selectable();
            Assert.Throws<ComposableNullException>(() => parent.Select(null));
            Assert.Throws<ComposableNullException>(() => parent.Deselect(null));
        }
    }
}

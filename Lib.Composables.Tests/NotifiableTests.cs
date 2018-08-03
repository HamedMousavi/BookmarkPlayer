using System.Collections.Generic;
using Xunit;


namespace Lib.Composables.Tests
{

    public class NotifiableTests
    {
        [Fact]
        public void AddEventShouldBeObservable()
        {
            var parent = new Notifiable();
            var children = new List<Composable>
            {
                new Composable("Child 1"),
                new Composable("Child 2"),
                new Composable("Child 3"),
                new Composable("Child 4")
            };
            
            var eventRaisedCount = 0;

            parent.When<Added>(e =>
            {
                Assert.NotNull(e.Composable());
                Assert.True(parent.Contains(e.Composable()));
                eventRaisedCount++;
            });

            foreach (var child in children) parent.Add(child);

            Assert.Equal(eventRaisedCount, parent.Count);
            Assert.Equal(eventRaisedCount, children.Count);
        }
    }


}

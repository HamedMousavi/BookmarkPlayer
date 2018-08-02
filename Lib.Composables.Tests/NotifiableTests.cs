﻿using System.Collections.Generic;
using System.Linq;
using Xunit;


namespace Lib.Composables.Tests
{

    public class NotifiableTests
    {
        [Fact]
        public void AddEventShouldBeObservable()
        {
            var parent = new Composable("parent");
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
                Assert.NotNull(e.AddedItem);
                Assert.True(parent.Contains(e.AddedItem));
                eventRaisedCount++;
            });

            foreach (var child in children) parent.Add(child);

            Assert.Equal(eventRaisedCount, parent.Count);
            Assert.Equal(eventRaisedCount, children.Count);
        }
    }


}
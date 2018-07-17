using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class BookmarkableTests
    {

        [Fact]
        public void BookmarkableShouldAllowToggle()
        {
            var parent = new Bookmarkable();
            var child1 = new Bookmarkable();

            parent.Add(child1);
            parent.ToggleBookmark(child1);
            Assert.True(parent.IsBookmarked(child1));
            Assert.True(child1.IsBookmarkedIn(parent));

            parent.ToggleBookmark(child1);
            Assert.False(parent.IsBookmarked(child1));
            Assert.False(child1.IsBookmarkedIn(parent));
        }
    }
}

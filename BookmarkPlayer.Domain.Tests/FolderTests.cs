using System.Linq;
using Xunit;


namespace BookmarkPlayer.Domain.Tests
{

    public class FolderTests
    {

        [Fact]
        public void NamableShouldBeNamable()
        {
            var courses = new Folder();
            var course1 = new Folder("Akka .Net", "C:\\Akka");
            var course2 = new Folder("Scalability", "C:\\Scale");
            var course3 = new Folder("Clean Code", "C:\\CC");

            courses.Add(course1);
            courses.Add(course2);
            courses.Add(course3);

            var result = courses.Search(new AwfulSearchEngine(), "Clean Code");
            Assert.Single(result);
            Assert.True(result.First().Found == course3);

            result = courses.Search(new AwfulSearchEngine(), "Scala");
            Assert.Single(result);
            Assert.True(result.First().Found == course2);

            result = courses.Search(new AwfulSearchEngine(), "a");
            Assert.Equal(3, result.Count());

            result = courses.Search(new AwfulSearchEngine(), "l");
            Assert.Equal(2, result.Count());

            result = courses.Search(new AwfulSearchEngine(), "k");
            Assert.Single(result);
        }
    }
}

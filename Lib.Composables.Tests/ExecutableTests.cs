using System.Linq;
using Xunit;


namespace Lib.Composables.Tests
{

    public class ExecutableTests
    {

        [Fact]
        public void ExecutableMustExecute()
        {
            var list = new Executable
            {
                new Executable(),
                new Executable(),
                new Executable()
            };

            list.Execute();
            Assert.True(list.IsExecuted());
            foreach(var child in list) Assert.True(list.IsExecuted());
        }


        [Fact]
        public void ExecutableMustExecuteMultipleTimes()
        {
            var list = new Executable();

            list.Execute();
            list.Execute();
            list.Execute();

            Assert.True(list.IsExecuted());
            Assert.True(list.ExecutionHistory().Count() == 3);
        }


        [Fact]
        public void ExecutableMustReportProgressOfAllChildren()
        {
            var list = new Executable
            {
                new Executable(),
                new Executable(),
                new Executable()
            };

            list.Execute();
            Assert.True(list.ExecutionProgress().Percentage() == 100);
        }


        [Fact]
        public void ExecutableMustReportProgressOfNoneOfChildren()
        {
            var list = new Executable
            {
                new Executable(),
                new Executable(),
                new Executable()
            };

            Assert.True(list.ExecutionProgress().Percentage() == 0);
        }


        [Fact]
        public void ExecutableMustReportProgressOfSomeOfChildren()
        {
            var list = new Executable
            {
                new Executable(),
                new Executable(),
                new Executable()
            };
            list.Execute();
            list.Add(new Executable());

            Assert.True(list.ExecutionProgress().Percentage() == 75);
        }
    }
}

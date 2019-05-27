using MemoRun.Windows.Desktop.Actors.Events;
using System;
using Xunit;

namespace MemoRun.Windows.Desktop.Tests
{
    public class CoolEvent : IEvent { }

    public class UnitTest1 : IEventSubscriber<CoolEvent>
    {
        [Fact]
        public void Test1()
        {
            var sut = new Broadcaster();
            sut.Subscribe(this);
            sut.Publish(new CoolEvent());
        }

        public void When(CoolEvent e)
        {
            
        }
    }
}

using Idler.Model;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Idler.xUnit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IdleTask it = new IdleTask();
            Task t = new Task(() => it.TimerStart());
            t.Start();
            t.Wait(10000);
            it.TimerStop();
        }
    }
}

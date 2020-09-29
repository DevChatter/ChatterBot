using ChatterBot.Domain.State;
using System.Collections.Generic;

namespace ChatterBot.Tests.Domain.State
{
    public class TestSet : BaseSet<string>
    {
        public TestSet(List<string> data) : base(data)
        {
        }
    }
}
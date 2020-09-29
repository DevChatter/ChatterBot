using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChatterBot.Tests.Domain.State
{
    public class TestSet_Should
    {

        [Fact]
        public void AddAllHandlers_GivenInInitialize()
        {
            string item1 = "Item 1";

            var testSet = new TestSet(new List<string> { item1 });

            testSet.Items.Single().Should().BeSameAs(item1);
        }

        [Fact]
        public void AddHandler_OnRegister()
        {
            string item1 = "Item 1";
            string item2 = "Item 2";
            var testSet = new TestSet(new List<string>());

            testSet.Register(item1);
            testSet.Register(item2);

            testSet.Items.Should().ContainSingle(x => x == item1);
            testSet.Items.Should().ContainSingle(x => x == item2);
        }

        [Fact]
        public void RemoveHandler_OnUnRegister()
        {
            string item1 = "Item 1";
            string item2 = "Item 2";
            var testSet = new TestSet(new List<string> { item1, item2 });

            testSet.UnRegister(item1);
            testSet.Items.Should().NotContain(x => x == item1);

            testSet.UnRegister(item2);
            testSet.Items.Should().NotContain(x => x == item2);

            testSet.Items.Should().BeEmpty();
        }
    }
}

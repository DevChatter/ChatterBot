using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ChatterBot.Tests.Domain.State
{
    public class TestSet_Should
    {
        private readonly TestSet _testSet;

        public TestSet_Should()
        {
            _testSet = new TestSet();
        }

        [Fact]
        public void NotChangeCollection_AfterInitialize()
        {
            var original = _testSet.Items;

            _testSet.Initialize(new List<string>());

            _testSet.Items.Should().BeSameAs(original);
        }

        [Fact]
        public void AddAllHandlers_GivenInInitialize()
        {
            string item1 = "Item 1";

            _testSet.Initialize(new[] { item1 });

            _testSet.Items.Single().Should().BeSameAs(item1);
        }

        [Fact]
        public void AddHandler_OnRegister()
        {
            string item1 = "Item 1";
            string item2 = "Item 2";
            _testSet.Initialize(new string[] { });

            _testSet.Register(item1);
            _testSet.Register(item2);

            _testSet.Items.Should().ContainSingle(x => x == item1);
            _testSet.Items.Should().ContainSingle(x => x == item2);
        }

        [Fact]
        public void RemoveHandler_OnUnRegister()
        {
            string item1 = "Item 1";
            string item2 = "Item 2";
            _testSet.Initialize(new[] { item1, item2 });

            _testSet.UnRegister(item1);
            _testSet.Items.Should().NotContain(x => x == item1);

            _testSet.UnRegister(item2);
            _testSet.Items.Should().NotContain(x => x == item2);

            _testSet.Items.Should().BeEmpty();
        }
    }
}

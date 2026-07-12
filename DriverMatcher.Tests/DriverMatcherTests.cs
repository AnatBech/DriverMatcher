using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace DriverFinder.Tests
{
    [TestFixture]
    public class DriverMatcherTests
    {
        private DriverMatcher _matcher = null!;

        [SetUp]
        public void Setup()
        {
            _matcher = new DriverMatcher();
            _matcher.AddDriver(new Driver(1, 0, 0));
            _matcher.AddDriver(new Driver(2, 10, 10));
            _matcher.AddDriver(new Driver(3, 2, 2));
            _matcher.AddDriver(new Driver(4, 3, 3));
            _matcher.AddDriver(new Driver(5, 100, 100));
            _matcher.AddDriver(new Driver(6, 1, 1));
            _matcher.AddDriver(new Driver(7, 4, 4));
            _matcher.AddDriver(new Driver(8, 5, 5));
            _matcher.AddDriver(new Driver(9, 6, 6));
            _matcher.AddDriver(new Driver(10, 7, 7));
        }

        [Test]
        public void FindNearestSimple_ReturnsCorrectCount()
        {
            var order = new Order(0, 0);
            var result = _matcher.FindNearestSimple(order, 5);

            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void FindNearestWithHeap_ReturnsCorrectCount()
        {
            var order = new Order(0, 0);
            var result = _matcher.FindNearestWithHeap(order, 5);

            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void FindNearestQuickSelect_ReturnsCorrectCount()
        {
            var order = new Order(0, 0);
            var result = _matcher.FindNearestQuickSelect(order, 5);

            Assert.That(result.Count, Is.EqualTo(5));
        }

        [Test]
        public void AllAlgorithmsReturnSameNearestDrivers()
        {
            var order = new Order(0, 0);
            var simple = _matcher.FindNearestSimple(order, 5).Select(d => d.Id).OrderBy(id => id).ToList();
            var heap = _matcher.FindNearestWithHeap(order, 5).Select(d => d.Id).OrderBy(id => id).ToList();
            var quick = _matcher.FindNearestQuickSelect(order, 5).Select(d => d.Id).OrderBy(id => id).ToList();

            Assert.That(simple, Is.EqualTo(heap));
            Assert.That(simple, Is.EqualTo(quick));
        }
    }
}
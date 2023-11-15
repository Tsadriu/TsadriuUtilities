using System.Globalization;
using TsadriuUtilities;
using TsadriuUtilities.Collections;
using TsadriuUtilities.Enums;

namespace Test
{
    [TestFixture]
    public class CollectionHelperTest
    {
        private IEnumerable<int> _testCollection = null!;

        [SetUp]
        public void Setup()
        {
            _testCollection = Enumerable.Range(1, 5);
        }

        [Test]
        public void ContainsAll_ItemsPresentInCollection_ReturnsTrue()
        {
            int[] items = { 1, 3, 5 };
            bool result = _testCollection.ContainsAll(items);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsAll_ItemsNotPresentInCollection_ReturnsFalse()
        {
            int[] items = { 6, 7 };
            bool result = _testCollection.ContainsAll(items);
            Assert.That(result, Is.False);
        }

        [Test]
        public void ContainsAny_ItemPresentInCollection_ReturnsTrue()
        {
            int[] items = { 6, 2, 7 };
            bool result = _testCollection.ContainsAny(items);
            Assert.That(result, Is.True);
        }

        [Test]
        public void ContainsAny_ItemNotPresentInCollection_ReturnsFalse()
        {
            int[] items = { 6, 7 };
            bool result = _testCollection.ContainsAny(items);
            Assert.That(result, Is.False);
        }
    }
}

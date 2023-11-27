using NUnit.Framework;
using NUnit.Framework.Legacy;
namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            Test1();
        }

        [Test]
        public void Test1()
        {
            ClassicAssert.AreEqual(1,1);
        }
    }
}
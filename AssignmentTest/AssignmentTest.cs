using Assignment;

namespace AssignmentTest
{
    [TestClass]
    public class AssignmentTests
    {
        [TestMethod]
        public void ConstructorTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.GetmaxCount(), PackMaxItems);
        }
    }
}

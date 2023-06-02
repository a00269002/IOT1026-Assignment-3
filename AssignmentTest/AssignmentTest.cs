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

            Assert.AreEqual(pack.GetMaxCount(), PackMaxItems);
            Assert.AreEqual(pack.GetMaxVolume(), PackMaxVolume);
            Assert.AreEqual(pack.GetMaxWeight(), PackMaxWeight);
        }

        [TestMethod]
        public void VolumeOverflowTest()
        {
            const int PackMaxItems = 1000;
            const float PackMaxVolume = 1;
            const float PackMaxWeight = 3000;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Water()), false);
        }

        [TestMethod]
        public void WeightOverflowTest()
        {
            const int PackMaxItems = 1000;
            const float PackMaxVolume = 5000;
            const float PackMaxWeight = 1;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.Add(new Sword()), false);
        }

        [TestMethod]
        public void AddSingleItemToEmptyPack()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            InventoryItem item = new Arrow();

            Assert.IsTrue(pack.Add(new Arrow()));
            Assert.AreEqual(1, pack.GetItems().Count());
        }

        
    }
}

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
            const float PackMaxVolume = 5;
            const float PackMaxWeight = 3000;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Bow()), true);
            Assert.AreEqual(pack.Add(new Bow()), false);
        }

        [TestMethod]
        public void WeightOverflowTest()
        {
            const int PackMaxItems = 1000;
            const float PackMaxVolume = 5000;
            const float PackMaxWeight = 3;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Bow()), true);
            Assert.AreEqual(pack.Add(new Bow()), false);
        }

        [TestMethod]
        public void AddSingleItemToEmptyPack()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            InventoryItem item = new Arrow();

            bool result = pack.Add(item);

            Assert.IsTrue(result);
            Assert.AreEqual(1, pack.GetMaxCount());
            //Assert.AreEqual(item, pack.GetItem(0));
        }

        [TestMethod]
        public void AddMultipleItemsWithConstraints()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            InventoryItem item1 = new Arrow();
            InventoryItem item2 = new Bow();

            bool result1 = pack.Add(item1);
            bool result2 = pack.Add(item2);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.AreEqual(2, pack.GetMaxCount());
            //Assert.AreEqual(item1, pack.GetItem(0));
            //Assert.AreEqual(item2, pack.GetItem(1));
        }

        [TestMethod]
        public void AddItemsExceedingConstraints()
        {
            const int PackMaxItems = 2;
            const float PackMaxVolume = 5;
            const float PackMaxWeight = 10;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            InventoryItem item1 = new Arrow();
            InventoryItem item2 = new Bow();
            InventoryItem item3 = new Sword();

            bool result1 = pack.Add(item1);
            bool result2 = pack.Add(item2);
            bool result3 = pack.Add(item3);

            Assert.IsTrue(result1);
            Assert.IsTrue(result2);
            Assert.IsFalse(result3);
            Assert.AreEqual(2, pack.GetMaxCount());
            //Assert.AreEqual(item1, pack.GetItem(0));
            //Assert.AreEqual(item2, Pack._items[1]);
        }
    }
}

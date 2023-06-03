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
        public void AddSingleItemToEmptyPackTest()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;

            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            Assert.AreEqual(pack.Add(new Arrow()), true);
            Assert.AreEqual(1, pack.GetItems().Count());
        }

        [TestMethod]
        public void AddItemsExceedingConstraintsTest()
        {
            const int PackMaxItems = 2;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.Add(new Water()), true);
            Assert.AreEqual(pack.Add(new Food()), true);
            Assert.AreEqual(pack.Add(new Sword()), false);
            Assert.AreEqual(2, pack.GetItems().Count());
        }

        [TestMethod]
        public void AddItemsExactConstraintsTest()
        {
            const int PackMaxItems = 4;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(pack.Add(new Water()), true);
            Assert.AreEqual(pack.Add(new Food()), true);
            Assert.AreEqual(pack.Add(new Sword()), true);
            Assert.AreEqual(pack.Add(new Bow()), true);
            Assert.AreEqual(4, pack.GetItems().Count());
        }

        [TestMethod]
        public void PackClassNegativeValuesTest()
        {
            const int PackMaxItems = -3;
            const float PackMaxVolume = -5;
            const float PackMaxWeight = -10;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);

            Assert.AreEqual(PackMaxItems, pack.GetMaxCount());
            Assert.AreEqual(PackMaxVolume, pack.GetMaxVolume());
            Assert.AreEqual(PackMaxWeight, pack.GetMaxWeight());
        }

        [TestMethod]
        public void TestToString()
        {
            var pack = new Pack();
            var expectedString = $"Pack is current at {pack.GetItems().Count}/{pack.GetMaxCount()} items, {pack.GetWeight()}/{pack.GetMaxWeight()} weight, and {pack.GetVolume()}/{pack.GetMaxVolume()} volume.";

            var result = pack.ToString();

            Assert.AreEqual(expectedString, result);
        }

        [TestMethod]
        public void TestPack()
        {
            const int PackMaxItems = 10;
            const float PackMaxVolume = 20;
            const float PackMaxWeight = 30;
            Pack pack = new(PackMaxItems, PackMaxVolume, PackMaxWeight);
            PackTester.AddEquipment(pack);

            List<InventoryItem> items = new List<InventoryItem>();
            items.Add(new Sword());
            items.Add(new Rope());
            items.Add(new Water());
            items.Add(new Food());
            items.Add(new Bow());
            items.Add(new Arrow());

            foreach (var item in items)
            {
                Assert.AreEqual(item.Display(), pack.GetItems());
            }
        }
    }
}

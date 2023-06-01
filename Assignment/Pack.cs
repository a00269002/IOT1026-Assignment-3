namespace Assignment;

public class Pack
{
    private readonly InventoryItem[] _items; // You can use another data structure here if you prefer.
                                             // You may need another private member variable if you use an array data structure.

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;
    private int _currentCount;

    //Default constructor, set maxCount = 10, maxVolume = 20 and maxWeight = 30
    public Pack() : this(10, 20, 30) { }

    //Parametrized constructor,but it is a good start
    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        _items = new InventoryItem[maxCount];
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
        _items[0] = new Sword(); // Generate NullReferenceExeption
    }

    //Getter
    public int GetmaxCount()
    {
        return _maxCount;
    }

    public bool Add(InventoryItem item)
    {
        //Verify that the incoming items 
        float weight = item.GetWeight();// Validate if this is that we need to implement in this method
        throw new NotImplementedException();
    }

    // Implement this class
    public override string ToString()
    {
        throw new NotImplementedException();
    }
}

public abstract class InventoryItem
{
    private readonly float _volume;
    private readonly float _weight;

    protected InventoryItem(float volume, float weight)
    {
        if (volume <= 0f || weight <= 0f)
        {
            throw new ArgumentOutOfRangeException($"An item cannot have {volume} volume or {weight} weight!");
        }
        _volume = volume;
        _weight = weight;
    }

    //Getters
    public float GetVolume()
    {
        return _volume;
    }

    public float GetWeight()
    {
        return _weight;
    }
}



// Implement these classes - each inherits from InventoryItem
// 1 line of code each - call base class constructor with appropriate arguments
public class Arrow : InventoryItem
{
    public Arrow() : base(0.05f, 0.1f) { }

    public override string Display()
    {
        return $"An Arrow weight {GetWeight()} and volume {GetVolume()}";
    }
}
class Bow : InventoryItem
{
    public Bow() : base(1f, 4f) { }
}
class Rope : InventoryItem
{
    public Rope() : base(1f, 1.5f) { }
}
class Water : InventoryItem
{
    public Water() : base(2f, 3f) { }
}
class Food : InventoryItem
{
    public Food() : base(1f, 0.5f) { }
}
class Sword : InventoryItem
{
    public Sword() : base(5f, 3f) { }
}

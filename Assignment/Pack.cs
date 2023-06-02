namespace Assignment;

public class Pack
{
    private readonly List<InventoryItem> _items;

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;
    private int _currentCount;
    private float _currentVolume;
    private float _currentWeight;


    // Default constructor sets the 
    // maxCount to 10 
    // maxVolume to 20 
    // maxWeight to 30
    public Pack() : this(10, 20, 30) { }

    // Paramtrized constructor
    public Pack(int maxCount, float maxVolume, float maxWeight)
    {
        _items = new List<InventoryItem>();
        _maxCount = maxCount;
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
    }

    // Getter
    public float GetVolume()
    {
        return _currentVolume;
    }

    public float GetWeight()
    {
        return _currentWeight;
    }

    public int GetMaxCount()
    {
        return _maxCount;
    }

    public float GetMaxVolume()
    {
        return _maxVolume;
    }

    public float GetMaxWeight()
    {
        return _maxWeight;
    }

    public bool Add(InventoryItem item)
    {
        float weight = item.GetWeight();
        float volume = item.GetVolume();
        if (_items.Count + 1 > GetMaxCount() || GetWeight() + weight > GetMaxWeight() || GetVolume() + volume > GetMaxVolume())
        {
            return false;
        }
        _items.Add(item);
        _currentWeight += weight;
        _currentVolume += volume;
        return true;

    }

    public override string ToString()
    {
        string result = $"Pack is current at {_items.Count}/{GetMaxCount()} items, {GetWeight()}/{GetMaxWeight()} weight, and {GetVolume()}/{GetMaxVolume()} volume.";
        return result;
    }
}

// Come back to this once we learn about abstract classes.
public abstract class InventoryItem
{
    private readonly float _volume;
    private readonly float _weight;

    protected InventoryItem(float volume, float weight)
    {
        if (volume <= 0f || weight <= 0f)
        {
            throw new ArgumentOutOfRangeException($"An item can't have {volume} volume or {weight} weight");
        }
        _volume = volume;
        _weight = weight;
    }

    // Returns a string representing the quantities of the item (volume & weight of the item)
    public abstract string Display();

    // Getters
    public float GetVolume()
    {
        return _volume;
    }

    public float GetWeight()
    {
        return _weight;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.05f, 0.1f) { }

    public override string Display()
    {
        return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

public class Bow : InventoryItem
{
    public Bow() : base(4f, 1f) { }

    public override string Display()
    {
        return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

public class Rope : InventoryItem
{
    public Rope() : base(1.5f, 1f) { }

    public override string Display()
    {
        return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
    }
}

public class Water : InventoryItem
{
    public Water() : base(3f, 2f) { }

    public override string Display()
    {
        return $"Water with weight {GetWeight()} and volume {GetVolume()}";
    }
}

public class Food : InventoryItem
{
    public Food() : base(0.5f, 1f) { }

    public override string Display()
    {
        return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
    }
}

public class Sword : InventoryItem
{
    public Sword() : base(3f, 5f) { }

    public override string Display()
    {
        return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
    }
}
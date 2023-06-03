namespace Assignment;

public class Pack
{
    private readonly List<InventoryItem> _items;

    private readonly int _maxCount;
    private readonly float _maxVolume;
    private readonly float _maxWeight;
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
    public List<InventoryItem> GetItems()
    {
        return _items;
    }

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

    /// <summary>
    /// Adds an inventory item to the pack.
    /// </summary>
    /// <param name="item">The inventory item to add.</param>
    /// <returns><c>true</c> if the item was successfully added; otherwise, <c>false</c>.</returns>
    public bool Add(InventoryItem item)
    {
        float weight = item.GetWeight();
        float volume = item.GetVolume();

        if (weight < 0 || volume < 0)
        {
            return false;
        }

        if (_items.Count + 1 > GetMaxCount() || GetWeight() + weight > GetMaxWeight() || GetVolume() + volume > GetMaxVolume())
        {
            return false;
        }
        _items.Add(item);
        _currentWeight += weight;
        _currentVolume += volume;
        return true;
    }

    /// <summary>
    /// Returns a string representation of the pack.
    /// </summary>
    /// <returns>A string representation of the pack indicating the current item count, weight, and volume.</returns>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="InventoryItem"/> class with the specified volume and weight.
    /// </summary>
    /// <param name="volume">The volume of the item.</param>
    /// <param name="weight">The weight of the item.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown when the volume or weight is less than or equal to zero.
    /// </exception>
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

/// <summary>
/// Represents an arrow.
/// </summary>
public class Arrow : InventoryItem
{
    // <summary>
    /// Initializes a new instance of the <see cref="Arrow"/> class.
    /// </summary>
    public Arrow() : base(0.05f, 0.1f) { }

    /// <summary>
    /// Displays information about the arrow.
    /// </summary>
    /// <returns>A string representation of the arrow.</returns>
    public override string Display()
    {
        return $"An arrow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

/// <summary>
/// Represents a bow.
/// </summary>
public class Bow : InventoryItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Bow"/> class.
    /// </summary>
    public Bow() : base(4f, 1f) { }

    /// <summary>
    /// Displays information about the bow.
    /// </summary>
    /// <returns>A string representation of the bow.</returns>
    public override string Display()
    {
        return $"A bow with weight {GetWeight()} and volume {GetVolume()}";
    }
}

/// <summary>
/// Represents a rope.
/// </summary>
public class Rope : InventoryItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Rope"/> class.
    /// </summary>
    public Rope() : base(1.5f, 1f) { }

    /// <summary>
    /// Displays information about the rope.
    /// </summary>
    /// <returns>A string representation of the rope.</returns>
    public override string Display()
    {
        return $"A rope with weight {GetWeight()} and volume {GetVolume()}";
    }
}

/// <summary>
/// Represents water.
/// </summary>
public class Water : InventoryItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Water"/> class.
    /// </summary>
    public Water() : base(3f, 2f) { }

    /// <summary>
    /// Displays information about the water.
    /// </summary>
    /// <returns>A string representation of the water.</returns>
    public override string Display()
    {
        return $"Water with weight {GetWeight()} and volume {GetVolume()}";
    }
}

/// <summary>
/// Represents food.
/// </summary>
public class Food : InventoryItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Food"/> class.
    /// </summary>
    public Food() : base(0.5f, 1f) { }

    /// <summary>
    /// Displays information about the food.
    /// </summary>
    /// <returns>A string representation of the food.</returns>
    public override string Display()
    {
        return $"Yummy food with weight {GetWeight()} and volume {GetVolume()}";
    }
}

/// <summary>
/// Represents a sword.
/// </summary>
public class Sword : InventoryItem
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sword"/> class.
    /// </summary>
    public Sword() : base(3f, 5f) { }

    // <summary>
    /// Gets or sets the volume of the sword.
    /// </summary>
    public override string Display()
    {
        return $"A sharp sword with weight {GetWeight()} and volume {GetVolume()}";
    }
}

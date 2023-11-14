namespace CodingChallenges.ConverterJson.Services;

// FIFO Dictionary implementation
public class FifoDictionary<TKey, TValue>
    where TKey : notnull
{
    public int Count => dictionary.Count;

    public void Add(TKey key, TValue value)
    {
        orderQueue.Enqueue(key);
        dictionary.Add(key, value);
    }

    public KeyValuePair<TKey, TValue> Dequeue()
    {
        if (orderQueue.Count == 0)
            throw new InvalidOperationException("The dictionary is empty.");

        var key = orderQueue.Dequeue();
        var value = dictionary[key];
        dictionary.Remove(key);

        return new KeyValuePair<TKey, TValue>(key, value);
    }

    //

    private readonly Queue<TKey> orderQueue = new();
    private readonly Dictionary<TKey, TValue> dictionary = new();
}
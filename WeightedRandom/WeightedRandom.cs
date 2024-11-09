namespace WeightedRandom;

// Thread safe
public class WeightedRandom
{
    // Generic method to select an item based on given probabilities
    public static T GetRandom<T>(IDictionary<T, decimal> probabilities)
    {
        // Sum of all the weights
        decimal totalWeight = 0;
        foreach (var probability in probabilities.Values)
        {
            totalWeight += probability;
        }

        // Generate a random number in the range [0, totalWeight]
        decimal randomValue = new decimal(Random.Shared.NextDouble()) * totalWeight;

        // Determine which item the random value corresponds to
        foreach (var item in probabilities)
        {
            randomValue -= item.Value;
            if (randomValue <= 0)
            {
                return item.Key;
            }
        }

        throw new Exception("Probabilities are invalid");
    }

    public static Dictionary<T, int> CountDifferentItems<T>(IEnumerable<T> items) where T : notnull
    {
        var dictionary = new Dictionary<T, int>();

        foreach (var item in items.Where(item => !dictionary.TryAdd(item, 1)))
        {
            dictionary[item] += 1;
        }

        return dictionary;
    }
}
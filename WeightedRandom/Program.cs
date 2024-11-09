using System.Text.Json;

namespace WeightedRandom;

class Program
{
    static void Main(string[] args)
    {
        var probabilities = new Dictionary<string, decimal>
        {
            { "A", 0.7m },
            { "B", 0.2m },
            { "C", 0.1m }  // The rest for C
        };

        var randomResults = new List<string>();
        
        // Run the function multiple times to see the weighted randomness
        for (int i = 0; i < 1000; i++)
        {
            randomResults.Add(WeightedRandom.GetRandom(probabilities));
        }
        
        Console.WriteLine(JsonSerializer.Serialize(WeightedRandom.CountDifferentItems(randomResults), new JsonSerializerOptions { WriteIndented = true }));
    }
}
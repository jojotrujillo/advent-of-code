namespace AdventOfCode2024;

public class Day1
{
    private static List<int> _leftListOfLocationIds = [];
    private static List<int> _rightListOfLocationIds = [];
    
    public void ReconcileListsOfLocationIds()
    {
        ReadFromDayOnesPuzzleInput();

        // Sort integers in separate lists in ascending order; smallest to largest
        var sortedLeftListOfLocationIds = _leftListOfLocationIds.OrderBy(x => x).ToList();
        var sortedRightListOfLocationIds = _rightListOfLocationIds.OrderBy(y => y).ToList();

        // Pairwise differences; take the absolute difference between the pairs of integers and add them together
        var totalDistance = sortedLeftListOfLocationIds
            .Zip(sortedRightListOfLocationIds, (a, b) => Math.Abs(a - b))
            .Sum();
        
        Console.WriteLine("Total Distance: " + totalDistance);
    }
    
    public void FindSimilarityScoreBetweenListsOfLocationIds()
    {
        ReadFromDayOnesPuzzleInput();

        // Create a dictionary to count occurrences in the right list ahead of time
        var rightListLocationIdCounts = new Dictionary<int, int>(); // {0 -> index, {86712 -> number, 1 -> occurrences}, 1, {96206, 1}, ...}
        foreach (var locationId in _rightListOfLocationIds)
        {
            if (rightListLocationIdCounts.TryGetValue(locationId, out var value))
                rightListLocationIdCounts[locationId] = ++value;
            else
                rightListLocationIdCounts[locationId] = 1;
        }

        // Add up each number in left list after multiplying it by the number of times it appears in the right list
        var similarityScore = 0;
        foreach (var locationId in _leftListOfLocationIds)
        {
            if (rightListLocationIdCounts.TryGetValue(locationId, out var count))
                similarityScore += locationId * count;
        }

        Console.WriteLine("Similarity Score: " + similarityScore);
    }
    
    private static void ReadFromDayOnesPuzzleInput()
    {
        _leftListOfLocationIds = [];
        _rightListOfLocationIds = [];
        
        foreach (var lineOfLocationIds in File.ReadLines("../../../../puzzle-inputs/day-1-puzzle-1-and-puzzle-2.txt"))
        {
            var arrayOfLocationIds = lineOfLocationIds.Split([' '], StringSplitOptions.RemoveEmptyEntries);
            
            _leftListOfLocationIds.Add(int.Parse(arrayOfLocationIds[0]));
            _rightListOfLocationIds.Add(int.Parse(arrayOfLocationIds[1]));
        }
    }
}

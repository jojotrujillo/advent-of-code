namespace AdventOfCode2024;

public class Day2
{
    private static List<List<int>> _listOfReports = [];
    
    public void FindNumberOfSafeReports()
    {
        ReadFromDayTwosPuzzleInput();

        var numberOfSafeReports = _listOfReports.Count( report => IsSafe(report) || CanBeMadeSafe(report) );

        Console.WriteLine( $"Number of safe reports: { numberOfSafeReports }" );
    }
    
    private static bool CanBeMadeSafe(List<int> report)
    {
        for (var index = 0; index < report.Count; index++)
        {
            // Create a modified report with one level removed
            var modifiedReport = new List<int>(report);
            modifiedReport.RemoveAt( index );

            // Check if the modified report is safe
            if (IsSafe(modifiedReport))
                return true;
        }
        
        return false;
    }
    
    private static bool IsSafe(List<int> report)
    {
        var isIncreasing = true;
        var isDecreasing = true;

        for (var i = 0; i < report.Count - 1; i++)
        {
            // Find the difference between adjacent levels
            var diff = report[i + 1] - report[i];

            // Check step size
            if (Math.Abs( diff ) < 1 || Math.Abs( diff ) > 3)
                return false;

            switch ( diff )
            {
                // Determine monotonicity
                case > 0:
                    isDecreasing = false;
                    break;
                case < 0:
                    isIncreasing = false;
                    break;
            }
        }

        // Safe if either increasing or decreasing
        return isIncreasing || isDecreasing;
    }

    private static void ReadFromDayTwosPuzzleInput()
    {
        _listOfReports = [];

        foreach (var report in File.ReadLines("../../../../puzzle-inputs/day-2-puzzle-1-and-puzzle-2.txt"))
        {
            var listOfLevels = new List<int>();
            foreach (var level in report.Split([' '], StringSplitOptions.RemoveEmptyEntries))
            {
                if (int.TryParse(level, out var number))
                {
                    listOfLevels.Add(number);
                }
            }
            
            _listOfReports.Add(listOfLevels);
        }
    }
}

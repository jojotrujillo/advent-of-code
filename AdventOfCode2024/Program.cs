namespace AdventOfCode2024;

class Program
{
    private static void Main(string[] args)
    {
        args = ["Day2"];
        
        switch (args)
        {
            case ["Day1"]:
                var day1 = new Day1();
                day1.ReconcileListsOfLocationIds();
                day1.FindSimilarityScoreBetweenListsOfLocationIds();
                break;
            
            case ["Day2"]:
                var day2 = new Day2();
                day2.FindNumberOfSafeReports();
                break;
        }
    }
}

namespace firstLab;

public class MyTask : ConsoleManager
{
    public void MatchesWithMaxGoalDifference(TeamOfContenders[] teamOfContendersArray)
    {
        int maxGoalDifference = int.MinValue;
        foreach (var team in teamOfContendersArray)
        {
            maxGoalDifference = Math.Max(maxGoalDifference, team.GoalDifference);
        }

        ApplyColor("\nMatches with the largest absolute difference between goals scored and missed:",
            ConsoleColor.Yellow);
        foreach (var team in teamOfContendersArray)
            if (team.GoalDifference == maxGoalDifference)
                Console.WriteLine($"{team.Name}: {team.GoalsScored} - {team.GoalsMissed}");
    }

    public void TotalNumberOfPointsScored(TeamOfContenders[] teamOfContendersArray)
    {
        double totalPoints = teamOfContendersArray.Sum(sum => sum.Points);
        TeamOfContenders[] sortedGames = SortedGames(teamOfContendersArray);

        ApplyColor("\nSorted in descending order by the number of points: ", ConsoleColor.Yellow);
        foreach (var game in sortedGames)
            Console.WriteLine($"{game.Name}: {game.Points}");

        ApplyColor("\nThe total number of points:", ConsoleColor.Red);
        Console.WriteLine($"Total points: {totalPoints}\n");
    }

    public void LostMatches(TeamOfContenders[] teamOfContendersArray)
    {
        int maxLostMatches = 0;
        for (int i = 0; i < teamOfContendersArray.Length; i++)
        {
            if (teamOfContendersArray[i].GoalsMissed > teamOfContendersArray[i].GoalsScored)
            {
                int lostMatches = 1;
                for (int j = i + 1; j < teamOfContendersArray.Length; j++)
                {
                    if (teamOfContendersArray[j].Name == teamOfContendersArray[i].Name &&
                        teamOfContendersArray[j].GoalsMissed > teamOfContendersArray[j].GoalsScored)
                    {
                        lostMatches++;
                    }
                }

                if (lostMatches > maxLostMatches)
                {
                    maxLostMatches = lostMatches;
                }
            }
        }

        ApplyColor("Teams that have lost the most matches:", ConsoleColor.Yellow);
        for (int i = 0; i < teamOfContendersArray.Length; i++)
        {
            if (teamOfContendersArray[i].GoalsMissed > teamOfContendersArray[i].GoalsScored)
            {
                int lostMatches = 1;
                for (int j = i + 1; j < teamOfContendersArray.Length; j++)
                {
                    if (teamOfContendersArray[j].Name == teamOfContendersArray[i].Name &&
                        teamOfContendersArray[j].GoalsMissed > teamOfContendersArray[j].GoalsScored)
                    {
                        lostMatches++;
                    }
                }

                if (lostMatches == maxLostMatches)
                {
                    Console.WriteLine($"{teamOfContendersArray[i].Name} - {lostMatches} lost matches");
                }
            }
        }
    }

    private static TeamOfContenders[] SortedGames(TeamOfContenders[] teamOfContendersArray)
    {
        for (int i = 0; i < teamOfContendersArray.Length; i++)
        {
            for (int j = 0; j < teamOfContendersArray.Length - 1 - i; j++)
            {
                if (teamOfContendersArray[j].Points < teamOfContendersArray[j + 1].Points)
                {
                    (teamOfContendersArray[j], teamOfContendersArray[j + 1]) =
                        (teamOfContendersArray[j + 1], teamOfContendersArray[j]);
                }
            }
        }
        
        return teamOfContendersArray;
    }
}


// int maxGoalMissed = int.MinValue;
// foreach (var team in teamOfContendersArray)
// {
//     maxGoalMissed = Math.Max(maxGoalMissed, team.GoalsMissed);
// }
// ApplyColor("Teams that have lost the most matches:", ConsoleColor.Yellow);
// foreach (var team in teamOfContendersArray)
// {
//     if (team.GoalsMissed == maxGoalMissed)
//         Console.WriteLine(team.Name);
// }
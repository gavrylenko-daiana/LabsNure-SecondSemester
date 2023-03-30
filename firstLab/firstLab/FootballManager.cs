using System;

namespace firstLab
{
    public class FootballManager : ConsoleManager
    {
        public void CreateFootballTeams(TeamOfContenders[] teamOfContendersArray)
        {
            int request = RequestUser("Choose how the data is filled in:\n" +
                                      "Enter '1' - Fill in at random\n" +
                                      "Enter '2' - Fill in by yourself\n");

            for (int i = 0; i < teamOfContendersArray.Length; i++)
            {
                string name = $"Team {i + 1}";
                int goalsScored = RandomValue();
                int goalsMissed = RandomValue();
                
                ApplyColor(name, ConsoleColor.Blue);

                switch (request)
                {
                    case 1:
                        Console.WriteLine($"Number of scored goals = {goalsScored}");
                        Console.WriteLine($"Number of missed goals = {goalsMissed}");
                        break;
                    case 2:
                        goalsScored = RequestUser("Number of scored goals = ");
                        goalsMissed = RequestUser("Number of missed goals = ");
                        break;
                    default:
                        Console.WriteLine("You entered an incorrect value!");
                        break;
                }

                teamOfContendersArray[i] = new TeamOfContenders
                {
                    Name = name,
                    GoalsScored = goalsScored,
                    GoalsMissed = goalsMissed
                };
            }
        }
    }
}

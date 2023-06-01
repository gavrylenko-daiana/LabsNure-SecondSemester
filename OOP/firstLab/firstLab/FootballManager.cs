using System;

namespace firstLab
{
    public class FootballManager : ConsoleManager
    {
        public void CreateFootballTeams(TeamOfContenders[] teamOfContendersArray)
        {
            teamOfContendersArray[0] = new TeamOfContenders
                { Name = "Team A", GoalsScored = 2, GoalsMissed = 1 };
            teamOfContendersArray[1] = new TeamOfContenders
                { Name = "Team B", GoalsScored = 1, GoalsMissed = 3 };
            teamOfContendersArray[2] = new TeamOfContenders
                { Name = "Team C", GoalsScored = 0, GoalsMissed = 2 };
            teamOfContendersArray[3] = new TeamOfContenders
                { Name = "Team Q", GoalsScored = 2, GoalsMissed = 1 };
            teamOfContendersArray[4] = new TeamOfContenders
                { Name = "Team A", GoalsScored = 2, GoalsMissed = 3 };
            teamOfContendersArray[5] = new TeamOfContenders
                { Name = "Team A", GoalsScored = 3, GoalsMissed = 0 };
            teamOfContendersArray[6] = new TeamOfContenders
                { Name = "Team B", GoalsScored = 2, GoalsMissed = 3 };
            teamOfContendersArray[7] = new TeamOfContenders
                { Name = "Team N", GoalsScored = 1, GoalsMissed = 1 };
            teamOfContendersArray[8] = new TeamOfContenders
                { Name = "Team B", GoalsScored = 3, GoalsMissed = 1 };
            teamOfContendersArray[9] = new TeamOfContenders
                { Name = "Team A", GoalsScored = 0, GoalsMissed = 1 };
        }
    }
}


// int request = RequestUser("Choose how the data is filled in:\n" +
//                           "Enter '1' - Fill in at random\n" +
//                           "Enter '2' - Fill in by yourself\n");
//
// for (int i = 0; i < teamOfContendersArray.Length; i++)
// {
//     string name = "";
//     int goalsScored = RandomValue();
//     int goalsMissed = RandomValue();
//     
//     ApplyColor(name, ConsoleColor.Blue);
//
//     switch (request)
//     {
//         case 1:
//             Console.WriteLine($"Number of scored goals = {goalsScored}");
//             Console.WriteLine($"Number of missed goals = {goalsMissed}");
//             break;
//         case 2:
//             goalsScored = RequestUser("Number of scored goals = ");
//             goalsMissed = RequestUser("Number of missed goals = ");
//             break;
//         default:
//             Console.WriteLine("You entered an incorrect value!");
//             break;
//     }
//
//     teamOfContendersArray[i] = new TeamOfContenders
//     {
//         Name = name,
//         GoalsScored = goalsScored,
//         GoalsMissed = goalsMissed
//     };
// }
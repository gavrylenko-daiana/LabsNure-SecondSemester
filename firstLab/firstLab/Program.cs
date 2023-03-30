//Результати ігор однієї футбольної команди з 10 командами суперниками записані в
//вигляді масиву структур (назва команди суперника, кількість м'ячів забитих і пропущених в матчі). 
// а) Визначити матчі з найбільшим модулем різниці забитих і пропущених м'ячів.
// б) Визначити загальне число очок, набраних командою (за виграш дається 3 очка, за нічию – 1.5, за програш - 0),
// відсортувати ігри  за спаданням числа  очок.
// в) Вивести команди, яким було найбільше програно матчів.

using System;

namespace firstLab
{
    class Program
    {
        static void Main(string[] args)
        {
            TeamOfContenders[] teamOfContenders = new TeamOfContenders[10];
            FootballManager footballManager = new FootballManager();
            MyTask task = new MyTask();

            footballManager.CreateFootballTeams(teamOfContenders);
            
            task.MatchesWithMaxGoalDifference(teamOfContenders);
            task.TotalNumberOfPointsScored(teamOfContenders);
            task.LostMatches(teamOfContenders);
        }
    }
}

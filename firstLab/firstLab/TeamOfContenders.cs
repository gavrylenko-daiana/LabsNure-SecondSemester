using System;

namespace firstLab
{
    public struct TeamOfContenders
    {
        public string Name { get; set; }
        public int GoalsScored { get; set; }
        public int GoalsMissed { get; set; }

        public int GoalDifference => Math.Abs(GoalsScored - GoalsMissed);
        
        public double Points => GoalsScored < GoalsMissed ? 0 : GoalsScored == GoalsMissed ? 1.5 : 3;
    }
}
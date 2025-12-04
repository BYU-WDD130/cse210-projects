namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        { }

        public override int RecordEvent()
        {
            return _pointsPerCompletion;
        }

        public override string GetStatus()
        {
            return "[∞]";
        }

        public override string Serialize()
        {
            return $"Eternal|{_name.Replace("|", "¦")}|{_description.Replace("|", "¦")}|{_pointsPerCompletion}";
        }

        public static EternalGoal Deserialize(string[] parts)
        {
            var name = parts[1].Replace("¦", "|");
            var desc = parts[2].Replace("¦", "|");
            var points = int.Parse(parts[3]);
            return new EternalGoal(name, desc, points);
        }
    }
}
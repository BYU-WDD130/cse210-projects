namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _isComplete = false;
        }

        public override int RecordEvent()
        {
            if (!_isComplete)
            {
                _isComplete = true;
                return _pointsPerCompletion;
            }
            return 0;
        }

        public override string GetStatus()
        {
            return _isComplete ? "[X]" : "[ ]";
        }

        public override string Serialize()
        {
            return $"Simple|{Escape(_name)}|{Escape(_description)}|{_pointsPerCompletion}|{_isComplete}";
        }

        private static string Escape(string s) => s.Replace("|", "¦");

        public static SimpleGoal Deserialize(string[] parts)
        {
            var name = parts[1].Replace("¦", "|");
            var desc = parts[2].Replace("¦", "|");
            var points = int.Parse(parts[3]);
            var complete = bool.Parse(parts[4]);

            var goal = new SimpleGoal(name, desc, points)
            {
                _isComplete = complete
            };

            return goal;
        }
    }
}
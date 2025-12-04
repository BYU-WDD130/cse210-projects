namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusOnCompletion;

        public ChecklistGoal(string name, string description, int points, int target, int bonus)
            : base(name, description, points)
        {
            _targetCount = target;
            _bonusOnCompletion = bonus;
            _currentCount = 0;
        }

        public override int RecordEvent()
        {
            if (_currentCount >= _targetCount) return 0;

            _currentCount++;

            if (_currentCount == _targetCount)
                return _pointsPerCompletion + _bonusOnCompletion;

            return _pointsPerCompletion;
        }

        public override string GetStatus()
        {
            var done = _currentCount >= _targetCount ? "[X]" : "[ ]";
            return $"{done} Completed {_currentCount}/{_targetCount}";
        }

        public override string Serialize()
        {
            return $"Checklist|{_name.Replace("|", "¦")}|{_description.Replace("|", "¦")}|{_pointsPerCompletion}|{_currentCount}|{_targetCount}|{_bonusOnCompletion}";
        }

        public static ChecklistGoal Deserialize(string[] parts)
        {
            var name = parts[1].Replace("¦", "|");
            var desc = parts[2].Replace("¦", "|");
            int points = int.Parse(parts[3]);
            int current = int.Parse(parts[4]);
            int target = int.Parse(parts[5]);
            int bonus = int.Parse(parts[6]);

            var goal = new ChecklistGoal(name, desc, points, target, bonus)
            {
                _currentCount = current
            };
            return goal;
        }
    }
}
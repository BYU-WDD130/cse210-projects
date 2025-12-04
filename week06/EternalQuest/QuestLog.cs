namespace EternalQuest
{
    public class QuestLog
    {
        private List<Goal> _goals = new List<Goal>();
        private int _score = 0;
        private HashSet<string> _badges = new HashSet<string>();

        public IReadOnlyList<Goal> Goals => _goals.AsReadOnly();
        public int Score => _score;

        public void AddGoal(Goal g) => _goals.Add(g);

        public void AddPoints(int pts)
        {
            if (pts > 0)
            {
                _score += pts;
                CheckBadges();
            }
        }

        public void RecordGoalEvent(int index)
        {
            int points = _goals[index].RecordEvent();
            AddPoints(points);
            Console.WriteLine($"You earned {points} points!");
        }

        public void ShowGoals()
        {
            if (!_goals.Any())
            {
                Console.WriteLine("No goals created yet.");
                return;
            }

            for (int i = 0; i < _goals.Count; i++)
                Console.WriteLine($"{i + 1}. {_goals[i]} ({_goals[i].GetType().Name})");
        }

        public void ShowScore()
        {
            Console.WriteLine($"Score: {_score}");
            int level = _score / 1000;
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Badges: {( _badges.Count == 0 ? "None" : string.Join(", ", _badges))}");
        }

        private void CheckBadges()
        {
            var thresholds = new Dictionary<int, string>()
            {
                {1000, "Bronze"},
                {5000, "Silver"},
                {10000, "Gold"}
            };

            foreach (var t in thresholds)
                if (_score >= t.Key) _badges.Add(t.Value);
        }

        // SAVE
        public void Save(string path)
        {
            using var w = new StreamWriter(path);
            w.WriteLine($"Score|{_score}");
            foreach (var g in _goals)
                w.WriteLine(g.Serialize());
        }

        // LOAD
        public void Load(string path)
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Save file not found.");
                return;
            }

            var lines = File.ReadAllLines(path);
            _goals.Clear();

            foreach (var line in lines)
            {
                var parts = line.Split('|');
                switch (parts[0])
                {
                    case "Score":
                        _score = int.Parse(parts[1]);
                        break;
                    case "Simple":
                        _goals.Add(SimpleGoal.Deserialize(parts));
                        break;
                    case "Eternal":
                        _goals.Add(EternalGoal.Deserialize(parts));
                        break;
                    case "Checklist":
                        _goals.Add(ChecklistGoal.Deserialize(parts));
                        break;
                }
            }

            Console.WriteLine("Data loaded.");
        }
    }
}
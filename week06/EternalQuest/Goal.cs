namespace EternalQuest
{
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _pointsPerCompletion;

        public string Name => _name;
        public string Description => _description;

        protected Goal(string name, string description, int pointsPerCompletion)
        {
            _name = name;
            _description = description;
            _pointsPerCompletion = pointsPerCompletion;
        }

        public abstract int RecordEvent();
        public abstract string GetStatus();
        public abstract string Serialize();

        public override string ToString()
        {
            return $"{GetStatus()} {Name} - {Description}";
        }
    }
}
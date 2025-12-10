class Running : Activity
{
    private double _distance; // en millas

    public Running(DateTime date, int lengthInMinutes, double distance) 
        : base(date, lengthInMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance() => _distance;

    public override double GetSpeed() => GetDistance() / LengthInMinutes * 60;

    public override double GetPace() => LengthInMinutes / GetDistance();
}
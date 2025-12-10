using System;

abstract class Activity
{
    // Variables privadas (encapsulación)
    private DateTime _date;
    private int _lengthInMinutes;

    // Constructor
    public Activity(DateTime date, int lengthInMinutes)
    {
        _date = date;
        _lengthInMinutes = lengthInMinutes;
    }

    // Propiedades públicas
    public DateTime Date => _date;
    public int LengthInMinutes => _lengthInMinutes;

    // Métodos abstractos que deben implementar las clases derivadas
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // Método de resumen
    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_lengthInMinutes} min) - " +
               $"Distance {GetDistance():0.0} miles, Speed {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}
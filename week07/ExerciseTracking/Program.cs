class Program
{
    static void Main(string[] args)
    {
        // Crear actividades
        var activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 3), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 3), 45, 12.0),
            new Swimming(new DateTime(2022, 11, 3), 60, 40)
        };

        // Mostrar resumen de cada actividad
        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Ojo este metodo es virtual para ser sobrescrito
    public virtual double GetArea()
    {
        return 0;
    }
}
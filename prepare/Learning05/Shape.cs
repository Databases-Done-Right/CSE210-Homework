public abstract class Shape {
    private string _color;

    // constructor
    public Shape(string color) {
        SetColor(color);
    }

    public abstract double GetArea();

    public string GetColor() {
        return _color;
    }

    private void SetColor(string color) {
        _color = color;
    }
}
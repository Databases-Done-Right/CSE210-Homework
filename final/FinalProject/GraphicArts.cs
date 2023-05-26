public class GraphicArts : Entry {
    //private Division _divisions = new Division;
    private string _medium = "";


    // constructor
    public GraphicArts() {
    }
    public GraphicArts(string name, string description) : base(name, description) {
    }
    public GraphicArts(string name, string description, string medium) : base(name, description) {
        _medium = medium;
    }

    public override void GetDetails() {
        // overridden at child level, polymorphism
    }
}
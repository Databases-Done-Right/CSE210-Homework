public class Other : Entry {
    private string _material = "";

    // constructor
    public Other() {
    }
    public Other(string name, string description) : base(name, description) {
    }
    public Other(string name, string description, string material) : base(name, description) {
        _material = material;
    }

    public override void GetDetails() {
        // overridden at child level, polymorphism
    }
}
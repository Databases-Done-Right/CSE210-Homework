public class Photo : Entry {
    //private Division _divisions = new Division;
    private int _width = 0;
    private int _height = 0;
    private string _subject = "";


    // constructor
    public Photo() {
    }
    public Photo(string name, string description) : base(name, description) {
    }
    public Photo(string name, string description, int width, int height, string subject) : base(name, description) {
        _width = width;
        _height = height;
        _subject = subject;
    }

    public override void GetDetails() {
        // overridden at child level, polymorphism
    }
}
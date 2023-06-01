public class GraphicArt : Entry {
    //private Division _divisions = new Division;
    private string _medium = "";


    // constructor
    public GraphicArt() {
    }
    public GraphicArt(Entry entry, string medium) : base(entry.GetName(), entry.GetDescription(), entry.GetDivision()) {
        _medium = medium;
    }
    public GraphicArt(string name, string description, string division, string place, string medium) : base(name, description, division, place) {
        _medium = medium;
    }

    protected override string GetDetails() {
        return "GraphicArt | " + GetName() + " | " + GetDescription() + " | " + GetDivision() + " | " + GetPlace() + " | " + _medium;
    }
    public override string GetEntryInfo() {
        string tbr = "Graphic Arts (" + GetDivision() + ")";
        if(GetPlace() != null && GetPlace() != "") {
            tbr += " (" + GetPlace() + ")";
        }
        tbr += " " + GetName() + " - " + GetDescription();
        tbr += " Medium: " + _medium;
        return tbr;
    }

}
public class Other : Entry {
    private string _material = "";

    // constructor
    public Other() {
    }
    public Other(Entry entry, string material) : base(entry.GetName(), entry.GetDescription(), entry.GetDivision()) {
        _material = material;
    }
    public Other(string name, string description, string division, string place, string material) : base(name, description, division, place) {
        _material = material;
    }

    protected override string GetDetails() {
        return "Other | " + GetName() + " | " + GetDescription() + " | " + GetDivision() + " | " + GetPlace() + " | " + _material;
    }
    public override string GetEntryInfo() {
        string tbr = "Other (" + GetDivision() + ")";
        if(GetPlace() != null && GetPlace() != "") {
            tbr += " (" + GetPlace() + ")";
        }
        tbr += " " + GetName() + " - " + GetDescription();
        tbr += " Material: " + _material;
        return tbr;
    }
}
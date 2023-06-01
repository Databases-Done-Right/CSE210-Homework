public class Photo : Entry {
    private string _subject = "";


    // constructor
    public Photo() {
    }
    public Photo(Entry entry, string subject) : base(entry.GetName(), entry.GetDescription(), entry.GetDivision()) {
        _subject = subject;
    }
    public Photo(string name, string description, string division, string place, string subject) : base(name, description, division, place) {
        _subject = subject;
    }

    protected override string GetDetails() {
        return "Photo | " + GetName() + " | " + GetDescription() + " | " + GetDivision() + " | " + GetPlace() + " | " + _subject;
    }
    public override string GetEntryInfo() {
        string tbr = "Photo (" + GetDivision() + ")";
        if(GetPlace() != null && GetPlace() != "") {
            tbr += " (" + GetPlace() + ")";
        }
        tbr += " " + GetName() + " - " + GetDescription();
        tbr += " Subject: " + _subject;
        return tbr;
    }
}
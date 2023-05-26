public class Entry {
    //private Division _divisions = new Division;
    private string _name = "";
    private string _description = "";
    private string _place = ""; // what place it ended up receiving
    private int _id = 0;


    // constructor
    public Entry() {
    }
    public Entry(string name, string description) {
        _name = name;
        _description = description;
    }
    
    public void AddEntry() {
        // calls this.SaveChanges();
    }
    public void DeleteEntry() {
    }
    public void EditEntry() {
        // calls this.SaveChanges();        
    }

    public virtual void GetDetails() {
        // overridden at child level, polymorphism
    }
    public string GetEntryName() {
        // returns name - desciption
        return "";
    }

    private void SaveChanges() {
        // saves any new or changed entry data automatically to file
    }
}
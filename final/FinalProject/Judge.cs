public class Judge : User {
    private List<Division> _divisions = new List<Division>();
    // constructor
    public Judge() {
    }

    private void JudgeEntry(int entryNumber) {
        // asks what place the specified entry is to recieve.
        // responsible for storing the data in a flat file.
        // will probably be calling Entry.SaveChanges() to do so.
    }
    public override void ViewReport() {
        // Shows a report of which entries they are responsible for judging
        // Without any identifying information which might bias them.
        // Perhaps a way to quick link to the entry and specify winners from here
        // In that instance, this function would be the one calling Judge.judgeEntry()
    }

}
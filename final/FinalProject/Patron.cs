public class Patron : User {
    List<Entry> _entries = new List<Entry>();
    private string _city = "";
    private string _state = "";
    private string _phoneNumber = "";

    // constructor
    public Patron() {
    }
    
    public void judgePeoplesChoice() {
        // lists the few divisions where a user can vote for people's choice
        // and allows them to cast their votes
    }
    private bool newFairSubmission() {
        // collects entry information and calls Entry.AddNew();
        return true;
    }
    public bool signUp() {
        // goes through the new user info gathering process
        // once gathered, it creates the new user
        // Probably calling User.addUser()
        return true;
    }
    public void VerifyEmailAddress() {
        // is invoked when the emailed to link is clicked out.
        // sets User._isEmailVerified() to true
    }
    public override void ViewReport() {
        // list entries they have made. No need to specify
        // entrant contact info as they know who they are
    }

}
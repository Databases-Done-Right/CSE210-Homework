public class User {
    private string _firstName = "";
    private string _lastName = "";
    private string _username = "";
    private string _password = "";
    private string _emailAddress = "";
    private bool _isEmailVerified = false; // no need to verify email addresses for admin created users

    // constructor
    public User() {
    }
    public User(string firstName, string lastName) {
        _firstName = firstName;
        _lastName = lastName;
    }

    protected void AddUser() {
        // calls this.SaveChanges();
    }
    protected void DeleteUser() {
        // calls this.listUsers() and prompts user to specify which to operate on
        // deletes the associated user file
        // user cannot delete themselves
    }
    protected void EditUser() {
        // calls this.listUsers() and prompts user to specify which to operate on
        // calls this.SaveChanges();        
    }

    private void ListUsers() {
        // lists all of the users that the currently logged in user
        // has sufficient permissions to see and/or operate on
    }
    public bool Login() {
        // prompt for username & password and check against file
        // files to take the format of users/username.txt
        // returns true on sucess
        return true;
    }

    public bool LogOut() {
        return true;
    }
    private void SaveChanges() {
        // saves any new or changed user data automatically to file
    }
    public virtual void ViewReport() {
        // over-ridden at child level, polymorphism
    }
}
public class Goal {
    private string _name = "";
    private string _description = "";
    protected bool _isComplete = false;
    protected int _pointValue = 0;
    protected string _goalType = "Basic";

    // constructor
    public Goal(string name, string description, int pointValue, bool isComplete = false) {
        _name = name;
        _description = description;
        _pointValue = pointValue;
        _isComplete = isComplete;
    }

    public virtual int CalculateScore() {
        if(_isComplete) { return _pointValue; } else { return 0; }
    }

    protected string GetBasicGoalData() {
        return $"{_goalType} | {_name} | {_description} | {_pointValue} | {_isComplete}";
    }
    public virtual string GetCurrentStatus() {
        string currentStatusMessage = "";
        if(_isComplete) {
            currentStatusMessage += "Completed";
        }
        else {
            currentStatusMessage += "In Progress";
        }
        return $"{this.GetGoalInformation()} ({currentStatusMessage})";
    }

    public virtual string GetGoalData() {
        return $"{this.GetBasicGoalData()}";
    }
    protected string GetGoalInformation() {
        return $"{_name} - {_description} - {_pointValue} Points";
    }

    public string GetGoalNameAndDescription() {
        return _name + " " + _description;
    }
    public bool GetGoalStatus() {
        return _isComplete;
    }
    public virtual int LogProgress() {
        _isComplete = true;
        return _pointValue;
    }
}
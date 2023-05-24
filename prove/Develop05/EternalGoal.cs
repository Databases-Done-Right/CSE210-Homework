public class EternalGoal : Goal {
    private int _timesPerformed = 0;
    // constructor
    public EternalGoal(string name, string description, int pointValue, bool isComplete = false, int timesPerformed=0) : base(name, description, pointValue, isComplete) {
        _goalType = "Eternal";
        _timesPerformed = timesPerformed;
    }
    public override int CalculateScore() {
        return _timesPerformed * _pointValue;
    }
    public override string GetCurrentStatus() {
        string currentStatusMessage = "Performed " + _timesPerformed + " Times";
        return $"{this.GetGoalInformation()} ({currentStatusMessage})";
    }
    public override string GetGoalData() {
        return $"{this.GetBasicGoalData()} | {_timesPerformed}";
    }
    public override int LogProgress() {
        _timesPerformed += 1;
        return _pointValue;
    }
}
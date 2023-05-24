public class ChecklistGoal : Goal {
    private int _bonusPoints = 0;
    private int _timesPerformed = 0;
    private int _targetNumberOfTimes = 0;
    // constructor
    public ChecklistGoal(string name, string description, int pointValue, int targetNumberOfTimes,  int bonusPoints, int timesPerformed=0, bool isComplete = false) : base(name, description, pointValue, isComplete) {
        _targetNumberOfTimes = targetNumberOfTimes;
        _timesPerformed = timesPerformed;
        _bonusPoints = bonusPoints;
        _goalType = "Checklist";
    }
    public override int CalculateScore() {
        int currentScore = _timesPerformed * _pointValue;
        if(_isComplete) { currentScore += _bonusPoints; }
        return  currentScore;
    }

    public override string GetCurrentStatus() {
        string currentStatusMessage = "";
        if(_isComplete) {
            currentStatusMessage += "Completed";
        }
        else {
            currentStatusMessage = "Performed " + _timesPerformed + " of " + _targetNumberOfTimes + " Times";
        }
        return $"{this.GetGoalInformation()}/{_bonusPoints} Bonus Points ({currentStatusMessage})";
    }
    public override string GetGoalData() {
        return $"{this.GetBasicGoalData()} | {_targetNumberOfTimes} | {_bonusPoints} | {_timesPerformed}";
    }
    public override int LogProgress() {
        _timesPerformed += 1;
        int pointsEarned = _pointValue;
        if(_timesPerformed >= _targetNumberOfTimes) {
            _isComplete = true;
            pointsEarned += _bonusPoints;
        }
        return pointsEarned;
    }
}
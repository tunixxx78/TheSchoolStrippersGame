using System;

[Serializable]
public class HighScoreElemt
{
    public string playerName;
    public int points;

    public HighScoreElemt(string name, int points)
    {
        playerName = name;
        //this.points = points;
        this.points = ScoringSystem.theScore;
        
        
    }
}

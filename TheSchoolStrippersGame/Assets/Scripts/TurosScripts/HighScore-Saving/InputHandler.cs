using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string fileName;
    public HighscoreHandler highscoreHandler;
    [SerializeField] string playerNameTwo;
    [SerializeField] TMP_Text playerPoints;
    int playerScore;

    List<InputEntry> entries = new List<InputEntry>();

    private void Awake()
    {
        playerScore = ScoringSystem.theScore;
        playerPoints.text = playerScore.ToString();
    }

    private void Start()
    {
        entries = FileHandler.ReadFromJson<InputEntry>(fileName);
        highscoreHandler = FindObjectOfType<HighscoreHandler>();
    }

    public void AddNameToList()
    {
        entries.Add(new InputEntry(nameInput.text, Random.Range(0, 100)));
        nameInput.text = "";
        //FileHandler.SaveToJson<InputEntry>(entries, fileName);
        highscoreHandler.AddHighscoreIfPossible(new HighScoreElemt(playerNameTwo, playerScore));
    }
}

using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TMP_Text scoreText;
    public TMP_Text killText;
    public int score;
    public int kills;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        score = 0;
        kills = 0;
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateUI();
    }

    public void AddKil()
    {
        kills += 1;
        // score += 100;
        UpdateUI();
    }

    private void UpdateUI()
    {
        scoreText.text = "Очки: " + score.ToString();
            
        if(killText != null)
            killText.text = "Убийств: " + kills;
    }
}
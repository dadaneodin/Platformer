using UnityEngine;
using TMPro;

public class UIPopap : MonoBehaviour
{
    public GameObject popupPanel;
    public TMP_Text finalScoreText;
    public TMP_Text killsText;

    void OnTriggerEnter2D(Collider2D collision)
    {
         if (collision.CompareTag("Player"))
        {
           OnLevelComplete();
        }
    }

    void OnLevelComplete()
    {
        FreezeGame();
        ShowResurlPopup();
    }

    void CalculateFinalScore()
    {
        finalScoreText.text = "Очки: " + ScoreManager.instance.score;
        killsText.text = "Убийств: " + ScoreManager.instance.kills;
    }
    void Update()
    {
        
    }

    void FreezeGame()
    {
        Time.timeScale = 0;
    }

    void ShowResurlPopup()
    {
        CalculateFinalScore();
        popupPanel.SetActive(true);
    }

    
}

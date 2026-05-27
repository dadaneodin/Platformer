using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishTrigger : MonoBehaviour
{
    [Header("Настройки уровня")]
    [Tooltip("Номер текущего уровня (1, 2 или 3)")]
    public int currentLevelIndex = 1;

    [Tooltip("Точное название сцены главного меню для выхода")]
    public string menuSceneName = "MainMenu";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Игрок вошёл в коллайдер");
            LevelManager.WinLvl(currentLevelIndex);
            SceneManager.LoadScene(menuSceneName);
        }
    }
}

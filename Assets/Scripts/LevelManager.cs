using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    void Start()
    {
        int reached = PlayerPrefs.GetInt("Reached", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = (i + 1 <= reached);

            if (buttons[i].transform.childCount > 1) 
                buttons[i].transform.GetChild(1).gameObject.SetActive(i + 1 > reached);
        }
    }

    public void LoadLvl(int id) => SceneManager.LoadScene(id);

    public static void WinLvl(int id) {
        if (id == PlayerPrefs.GetInt("Reached", 1)) PlayerPrefs.SetInt("Reached", id + 1);
    }
}

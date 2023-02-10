using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameFinishedManager : MonoBehaviour
{
    public GameObject endGameMenu;
    public TMP_Text enemiesDefeatedText, gameTimeText;
    public void ShowEndGameScreen(int points, float playtime)
    {
        endGameMenu.SetActive(true);
        enemiesDefeatedText.text = points.ToString() + " x " + "<size=70> <sprite=0>";
        gameTimeText.text = Mathf.RoundToInt(playtime).ToString();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

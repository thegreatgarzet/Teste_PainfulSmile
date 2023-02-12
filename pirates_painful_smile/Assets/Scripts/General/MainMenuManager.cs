using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameSettings gameSettings;

    public GameObject mainMenu, optionMenu;
    public TMP_Text sessionDurationText;
    public TMP_Text spawnTimerText;
    private void Start()
    {
        mainMenu.SetActive(true);
        sessionDurationText.text = gameSettings.sessionDuration.ToString();
        spawnTimerText.text = gameSettings.spawnTime.ToString();
    }
    public void ModifySessionDuration(float value)
    {
        gameSettings.sessionDuration += value;
        gameSettings.sessionDuration = Mathf.Clamp(gameSettings.sessionDuration, 60f, 300f);
        sessionDurationText.text = gameSettings.sessionDuration.ToString();
    }
    public void ModifySpawnTime(float value)
    {
        gameSettings.spawnTime += value;
        gameSettings.spawnTime = Mathf.Clamp(gameSettings.spawnTime, 5f, 50f);
        spawnTimerText.text = gameSettings.spawnTime.ToString();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameSettings settings;
    [SerializeField] TMP_Text timer_Text, countdown_Text;
    EnemySpawner spawner;
    float session_Duration;
    float enemies_Spawn_Time;
    public float countdown_Duration;

    public GameObject[] enemies_To_Spawn;
    public GameObject playerPrefab;
    public PlayerShip playerRef;
    public Vector2 playerPosition;

    public int session_points;
    GameFinishedManager gameFinishedManager;

    private void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
        gameFinishedManager = GetComponent<GameFinishedManager>();
        session_Duration = settings.sessionDuration;
        enemies_Spawn_Time = settings.spawnTime;
        spawner.manager = this;
    }
    private void Start()
    {
        StartCoroutine(GameRoutine());
    }
    
    IEnumerator GameRoutine()
    {
        float countdown = countdown_Duration;
        float last_SpawnTime=Time.time;

        playerRef = Instantiate(playerPrefab, playerPosition, Quaternion.identity).GetComponent<PlayerShip>();

        while (countdown>0)
        {
            countdown -= Time.deltaTime;
            countdown_Text.text = Mathf.RoundToInt(countdown).ToString();
            yield return null;
        }
        countdown_Text.text = "";
        StartCoroutine(spawner.SpawnEnemies(enemies_To_Spawn));
        

        while (session_Duration>0)
        {
            session_Duration -= Time.deltaTime;
            timer_Text.text = Mathf.RoundToInt(session_Duration).ToString();
            if (Time.time >= last_SpawnTime + enemies_Spawn_Time)
            {
                StartCoroutine(spawner.SpawnEnemies(enemies_To_Spawn));
                last_SpawnTime = Time.time;
            }
            if(session_Duration==0 || playerRef == null)
            {
                StopAllCoroutines();
                gameFinishedManager.ShowEndGameScreen(session_points, settings.sessionDuration - session_Duration);
            }
            yield return null;
        }
    }
    public void AddPoints(int points)
    {
        session_points += points;
    }
}

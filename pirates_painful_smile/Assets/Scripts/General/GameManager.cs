using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    EnemySpawner spawner;
    GameFinishedManager gameFinishedManager;
    [SerializeField]GameSettings settings;
    [SerializeField] TMP_Text timer_Text, countdown_Text;

    public GameObject[] enemies_To_Spawn;
    public GameObject playerPrefab;
    public PlayerShip playerRef;
    public Vector2 playerPosition;

    float sessionDuration;
    float enemies_SpawnTime;
    public float countdown_Duration;
    public int session_points;
    

    private void Awake()
    {
        spawner = GetComponent<EnemySpawner>();
        gameFinishedManager = GetComponent<GameFinishedManager>();
        sessionDuration = settings.sessionDuration;
        enemies_SpawnTime = settings.spawnTime;
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
        

        while (sessionDuration>0)
        {
            sessionDuration -= Time.deltaTime;
            timer_Text.text = Mathf.RoundToInt(sessionDuration).ToString();
            if (Time.time >= last_SpawnTime + enemies_SpawnTime)
            {
                StartCoroutine(spawner.SpawnEnemies(enemies_To_Spawn));
                last_SpawnTime = Time.time;
            }
            if(sessionDuration==0 || playerRef == null)
            {
                StopAllCoroutines();
                gameFinishedManager.ShowEndGameScreen(session_points, settings.sessionDuration - sessionDuration);
            }
            yield return null;
        }
    }
    public void AddPoints(int points)
    {
        session_points += points;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Vector2 spawnArea;
    public Vector2 checkArea;
    public LayerMask obstacleMask;
    public Color32 gizmo_Color;
    public GameManager manager;

    public IEnumerator SpawnEnemies(GameObject[] enemies_to_spawn)
    {
        

        for (int i = 0; i < enemies_to_spawn.Length; i++)
        {
            Vector2 spawn_point = Vector2.zero;
            bool spawnPointFree = false;

            while (!spawnPointFree)
            {
                spawn_point = new(Random.Range(-spawnArea.x / 2, spawnArea.x / 2), Random.Range(-spawnArea.y / 2, spawnArea.y / 2));
                spawnPointFree = !Physics2D.OverlapBox(spawn_point, checkArea, 0f, obstacleMask);
                print(spawnPointFree);
            }

            EnemyShip new_enemy = Instantiate(enemies_to_spawn[i], spawn_point, Quaternion.identity).GetComponent<EnemyShip>();
            new_enemy.transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            new_enemy.manager = manager;
            new_enemy.playerReference = manager.playerRef;
            new_enemy.transform.name = i.ToString();
        }
        yield return null;
    }

    private void OnDrawGizmosSelected()
    {

        Gizmos.color = gizmo_Color;
        Vector2 _pos = transform.position;
        Gizmos.DrawCube(_pos, spawnArea);

    }

}

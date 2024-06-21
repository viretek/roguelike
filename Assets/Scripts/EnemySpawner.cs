using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefabFirstType;
    public List<GameObject> SpawnedEnemies = new List<GameObject>();

    private void Start()
    {
        Vector3 RoomPos = transform.position;
        int AmountOfEnemiesFirstType = Random.Range(3, 11);
        for (int i = 0; i < AmountOfEnemiesFirstType; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefabFirstType, new Vector3(RoomPos.x + Random.Range(0f, 90f), RoomPos.y + Random.Range(0f, 90f), RoomPos.z), Quaternion.identity);
            enemy.tag = "Enemy";
            SpawnedEnemies.Add(enemy);
        }
    }
    public List<GameObject> GetSpawnedEnemies()
    {
        return SpawnedEnemies;
    }
}
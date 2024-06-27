using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject EnemyPrefabFirstType;
    public GameObject EnemyPrefabSecondType;
    public List<GameObject> SpawnedEnemiesC = new List<GameObject>();
    public List<GameObject> SpawnedEnemiesR = new List<GameObject>();


    private void Start()
    {
        Vector3 RoomPos = transform.position;
        int AmountOfEnemiesFirstType = Random.Range(2, 6);
        for (int i = 0; i < AmountOfEnemiesFirstType; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefabFirstType, new Vector3(RoomPos.x + Random.Range(0f, 90f), RoomPos.y + Random.Range(0f, 90f), RoomPos.z), Quaternion.identity, transform); // Добавлено transform в качестве родителя
            enemy.tag = "Enemy";
            SpawnedEnemiesC.Add(enemy);
        }
        for (int i = 0; i < AmountOfEnemiesFirstType; i++)
        {
            GameObject enemy = Instantiate(EnemyPrefabSecondType, new Vector3(RoomPos.x + Random.Range(0f, 90f), RoomPos.y + Random.Range(0f, 90f), RoomPos.z), Quaternion.identity, transform); // Добавлено transform в качестве родителя
            enemy.tag = "Enemy";
            SpawnedEnemiesR.Add(enemy);
        }
    }
    public List<GameObject> GetSpawnedEnemiesC()
    {
        return SpawnedEnemiesC;
    }
    public List<GameObject> GetSpawnedEnemiesR()
    {
        return SpawnedEnemiesR;
    }
}
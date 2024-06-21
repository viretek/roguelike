using UnityEngine;
using System.Collections.Generic;

public class EnemyCollector : MonoBehaviour
{
    public List<GameObject> enemies;
    public GameObject player;
    public GameObject enemy;
    public float speed;
    public bool IsPlayerHere = false;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        enemies = new List<GameObject>();
        _enemySpawner = GetComponent<EnemySpawner>();
        enemies = _enemySpawner.GetSpawnedEnemies();

        // Получаем ссылку на игрока
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("Кто");
        if (other.CompareTag("Player"))
        {
            IsPlayerHere = true;
        }
    }

    void FixedUpdate()
    {
        if (IsPlayerHere && player != null)
        {
            foreach (GameObject enemy in enemies)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class EnemyCollector : MonoBehaviour
{
    public List<GameObject> enemiesC;
    public List<GameObject> enemiesR;
    public GameObject player;
    public GameObject enemy;
    public float speed;
    public bool IsPlayerHere = false;
    private EnemySpawner _enemySpawner;

    void Start()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
        enemiesC = _enemySpawner.GetSpawnedEnemiesC();
        enemiesR = _enemySpawner.GetSpawnedEnemiesR();
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
            foreach (GameObject enemy in enemiesC)
            {
                if (enemy != null)
                {
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
                }
            }
            foreach (GameObject enemy in enemiesR)
            {
                if (enemy != null)
                {
                    enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, speed * Time.deltaTime);
                    //enemy.GetComponent<EnemyRangeFighterAttack>().Nado = true;
                }
            }
        }
    }

    public bool PlayerChecking()
    {
        return IsPlayerHere;
    }
}

using UnityEngine;
using System.Collections;

public class MoveTowardPlayer : MonoBehaviour
{
    public float speed = 5f;
    public float destroyDelay = 2f;

    private Transform player;
    private Vector3 initialDirection;
    private bool hasInitialDirection = false;

    void Start()
    {
        // Получаем ссылку на игрока
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        // Вычисляем направление от объекта к игроку
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        // Если у нас еще нет начального направления, сохраняем его
        if (!hasInitialDirection)
        {
            initialDirection = directionToPlayer;
            hasInitialDirection = true;
        }

        // Перемещаем объект в начальном направлении
        transform.Translate(initialDirection * speed * Time.deltaTime);

        // Уничтожаем объект через 2 секунды
        Destroy(gameObject, destroyDelay);
    }
}

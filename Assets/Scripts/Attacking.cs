using UnityEngine;
using System.Collections;

public class CrossSpawnerAndTimeSlowdown : MonoBehaviour
{
    public GameObject crossPrefab; 


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // Проверяем клик левой кнопкой мыши
        {
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Получаем позицию клика в мировых координатах
            spawnPos.z = 0f; // Устанавливаем глубину (z) для 2D игр
            Instantiate(crossPrefab, spawnPos, Quaternion.identity); // Спавним префаб креста
            Debug.Log("X coordinate: " + spawnPos.x + ", Y coordinate: " + spawnPos.y);
        }
    }

   
}

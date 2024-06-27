using UnityEngine;
using System.Collections;

public class CrossSpawnerAndTimeSlowdown : MonoBehaviour
{
    public GameObject crossPrefab; 


    void Update()
    {
        
        if (Input.GetMouseButtonDown(0)) // Проверяем клик левой кнопкой мыши
        {
            Vector3 spawnPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
            spawnPos.z = 0f;
            Instantiate(crossPrefab, spawnPos, Quaternion.identity); 
            Debug.Log("X coordinate: " + spawnPos.x + ", Y coordinate: " + spawnPos.y);
        }
    }

   
}
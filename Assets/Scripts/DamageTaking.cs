using UnityEngine;
using System.Collections.Generic;

public class DamageOnCollisionToPlayer : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("БЕГИ ПРОЧЬ ИЗ ДЕРЕВНИ");
        if (other.CompareTag("Player"))
        {
            other.GetComponent<ALIIIIVE>().TakeDamage();
            Debug.Log("Ох зря я сюда полез...");
        }
    }
}
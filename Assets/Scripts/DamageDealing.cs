using UnityEngine;
using System.Collections.Generic;

public class DamageOnCollision : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("Враг столкнулся с объектом.");
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage();
        }
    }
}


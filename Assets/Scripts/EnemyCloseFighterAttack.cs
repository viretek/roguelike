using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyCloseFighterAttack : MonoBehaviour
{
    private Animator animator; 
    public float Delay;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Кто то столкнулся с объектом.");

        if (other.CompareTag("Player"))
        {
            Debug.Log("ДА ЦЕ Ж ИГРОК");
            animator.SetTrigger("Attack");

        }
    }

}
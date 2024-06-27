using UnityEngine;
using System.Collections;

public class ALIIIIVE : MonoBehaviour
{
    public bool isDead = false;
    public void TakeDamage()
    {
        Die();
        Debug.Log("Объект погиб.");
    }
    

    private void Die()
    {
        // Устанавливаем флаг isDead в true
        isDead = true;

        GetComponent<Animator>().SetBool("isDead", isDead);
    }
}
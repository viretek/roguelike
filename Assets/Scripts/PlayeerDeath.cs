using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayeerDeath : MonoBehaviour
{
    public bool isDead = false;
    public void TakeDamage()
    {
        Die();
        Debug.Log("Объект погиб.");
    }
    

    private void Die()
    {
       SceneManager.LoadScene("MainMenu");
    }
}
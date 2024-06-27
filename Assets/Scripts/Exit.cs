using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadSceneOnKeyPress : MonoBehaviour
{
    public bool CharIsHere;
    private void Start()
    {
        CharIsHere = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CharIsHere = true;  
        }
        
    }

    private void Update()
    {
        if (CharIsHere = true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                ReloadScene();
            }
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour
{
    public float destroyTime = 5f; // Время до удаления объекта в секундах

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}

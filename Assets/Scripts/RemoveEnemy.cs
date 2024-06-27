using UnityEngine;

public class ReplaceObject : MonoBehaviour
{
    public GameObject replacementPrefab; // Префаб для замены

    public void ReplaceWithPrefab()
    {
        // Создаем новый объект из префаба
        GameObject replacement = Instantiate(replacementPrefab, transform.position, transform.rotation);

        // Удаляем этот объект
        Destroy(gameObject);
    }
}
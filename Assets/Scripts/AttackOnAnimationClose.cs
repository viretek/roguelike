using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePrefab : MonoBehaviour
{
    public GameObject prefab;

    public void CreatePrefabOnAnimationClose()
    {
        Instantiate(prefab, transform.position, transform.rotation);
    }
}
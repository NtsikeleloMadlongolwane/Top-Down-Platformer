using UnityEngine;
using System.Collections.Generic;

public class BallonSpanwer : MonoBehaviour
{

    public GameObject prefab; // Drag your object prefab here
    public Transform[] spawnPoints; // Set spawn locations in Inspector

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ActivateSpawner();
        }
    }
    public void ActivateSpawner()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (spawnedObjects.Count <= i || spawnedObjects[i] == null)
            {
                GameObject obj = Instantiate(prefab, spawnPoints[i].position, Quaternion.identity);
                spawnedObjects.Insert(i, obj);
            }
        }
    }

}

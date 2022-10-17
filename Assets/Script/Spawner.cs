using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    public bool isSpawning = true;

    private float spawnRate = 1f;
    private float xRange = Constants.xRange;
    private float ceiling = Constants.ceiling;

    void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            GameObject prefabToUse = fruitPrefabs[Random.Range(0, fruitPrefabs.Length)];
            Instantiate(
                prefabToUse,
                new Vector3(Random.Range(-xRange, xRange), ceiling, 0),
                prefabToUse.transform.rotation
            );
        }
    } 
}

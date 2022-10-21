using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] bombPrefabs;
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
            GameObject prefabToUse = bombPrefabs.Concat(fruitPrefabs).ToArray()[Random.Range(0, fruitPrefabs.Length)];
            Instantiate(
                prefabToUse,
                new Vector3(Random.Range(-xRange, xRange), ceiling, 0),
                prefabToUse.transform.rotation
            );
        }
    } 
}

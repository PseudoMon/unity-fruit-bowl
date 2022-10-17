using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField]
    private int initialLives = 3;
    private int currentLives;

    [SerializeField]
    private GameObject prefabToUse;

    void Create()
    {
        currentLives = initialLives;
    }

    // Update is called once per frame
    void Update()
    {
        Instantiate(
            prefabToUse,
            new Vector3(Random.Range(-Constants.xRange, Constants.xRange), Constants.ceiling, 0),
            prefabToUse.transform.rotation
        );
    }
}

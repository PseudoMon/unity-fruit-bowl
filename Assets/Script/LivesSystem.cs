using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSystem : MonoBehaviour
{
    [SerializeField]
    private int initialLives = 3;

    [SerializeField]
    private GameObject prefabToUse;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private GameObject gameOverScreen;

    private int currentLives;
    private List<GameObject> livesObjects = new List<GameObject>();

    void Start()
    {
        currentLives = initialLives;

        for (int i = 0; i < initialLives; i++)
        {
            GameObject newLifeIndicator = CreateLifeIndicator();
            newLifeIndicator.transform.Translate(Vector3.forward * -1f * i);
            livesObjects.Add(newLifeIndicator);
        }
    }

    GameObject CreateLifeIndicator()
    {
        Vector3 newPos = cam.ScreenToWorldPoint(
            new Vector3(20, cam.pixelHeight - 50, 2.5f)
        );

        return Instantiate(
            prefabToUse,
            newPos,
            prefabToUse.transform.rotation
        );
    }

    public void ReduceLife()
    {
        if (currentLives <= 0) return;

        currentLives -= 1;
        
        int lastIndex = livesObjects.Count - 1;
        Destroy(livesObjects[lastIndex]);
        livesObjects.RemoveAt(livesObjects.Count - 1);

        if (currentLives <= 0)
        {
            SetGameOverScreen();
        }
    }

    public void SetGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverScreen.SetActive(true);
    }
}

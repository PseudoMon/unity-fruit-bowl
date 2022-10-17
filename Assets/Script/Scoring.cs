using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private TMPro.TextMeshPro textComp;

    public int currentScore = 0;

    void Update()
    {
        transform.position = cam.ScreenToWorldPoint(
            new Vector3(cam.pixelWidth / 2, cam.pixelHeight - 100, 2.5f)
        );
        textComp.SetText(currentScore.ToString());
    }

    public void AddScore(int scoreToAdd = 1)
    {
        currentScore += scoreToAdd;
    }
}

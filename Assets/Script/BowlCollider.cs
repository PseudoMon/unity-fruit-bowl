using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlCollider : MonoBehaviour
{
    [SerializeField]
    private Scoring scorer;

    [SerializeField]
    private LivesSystem lives;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        { 
            scorer.AddScore(); 
        }

        if (other.gameObject.CompareTag("Bomb"))
        {
            lives.ReduceLife();
        }

        Destroy(other.gameObject);
    }
}

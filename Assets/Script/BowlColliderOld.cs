using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlColliderOld : MonoBehaviour
{
    // fruitsInBowl contain fruits that have touched the bowl
    // key is the object's ID, value is the seconds when they touched.
    Dictionary<int, float> fruitsInTime = new Dictionary<int, float>(); 
    Dictionary<int, GameObject> fruitsInBowl = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float now = Time.time;
        foreach (KeyValuePair<int, float> kvp in fruitsInTime)
        {
            if (kvp.Value > now + 1f)
            {
                fruitsInBowl.Remove(kvp.Key);
                fruitsInTime.Remove(kvp.Key);
                Destroy(fruitsInBowl[kvp.Key]);
                // Score +1
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            GameObject fruit = collision.gameObject;
            fruitsInTime[fruit.GetInstanceID()] = Time.time;
            fruitsInBowl[fruit.GetInstanceID()] = fruit;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        int fruitID = collision.gameObject.GetInstanceID();
        if (fruitsInBowl.ContainsKey(fruitID))
        {
            fruitsInTime.Remove(fruitID);
            fruitsInBowl.Remove(fruitID);
        }
    }
}

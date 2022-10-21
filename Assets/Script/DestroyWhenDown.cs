using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenDown : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < Constants.underfloor)
        {
            Destroy(gameObject);
        }       
    }
}

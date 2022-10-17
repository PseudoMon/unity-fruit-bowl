using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowlControl : MonoBehaviour
{
    private float xRange = Constants.xRange;
    public float speed = 10;

    // Update is called once per frame
    void Update()
    {
        float leftRightInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * leftRightInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}

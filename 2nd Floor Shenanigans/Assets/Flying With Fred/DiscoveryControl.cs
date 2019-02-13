using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiscoveryControl : MonoBehaviour
{
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 10);

        if (direction > 5)
        {
            transform.Rotate(0, 180, 0);
            transform.position = new Vector3(340, Random.Range(0, 130), 0);
            GetComponent<Rigidbody2D>().velocity = new Vector3(-60, Random.Range(-15, -3), 0);
        }
        else
        {
            transform.position = new Vector3(-340, Random.Range(0, 130), 0);
            GetComponent<Rigidbody2D>().velocity = new Vector3(60, Random.Range(-15, -3), 0);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 5)
        {
            if (transform.position.x < -340)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (transform.position.x > 340)
            {
                Destroy(gameObject);
            }
        }
    }
}

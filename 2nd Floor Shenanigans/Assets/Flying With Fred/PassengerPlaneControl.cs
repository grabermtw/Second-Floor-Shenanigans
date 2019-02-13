using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassengerPlaneControl : MonoBehaviour
{
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Random.Range(0, 10);

        if(direction > 5)
        {
            transform.Rotate(0, 180, 0);
            transform.position = new Vector3(400, Random.Range(-130, 130), 0);
            GetComponent<Rigidbody2D>().velocity = new Vector3(-50, Random.Range(-10, 10), 0);
        }
        else
        {
            transform.position = new Vector3(-400, Random.Range(-130, 130), 0);
            GetComponent<Rigidbody2D>().velocity = new Vector3(50, Random.Range(-10, 10), 0);
        }
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (direction > 5)
        {
            if (transform.position.x < -400)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if(transform.position.x > 400)
            {
                Destroy(gameObject);
            }
        }
    }
}

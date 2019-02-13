using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalconBoosterControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-230, 230), 320, 0);
        //transform.position = new Vector3(0, -250, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-10, 10), -75, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 4, 0));
        if (transform.position.y < -180)
        {
            Destroy(gameObject);
        }
    }
}

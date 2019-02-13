using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnVControl : MonoBehaviour
{
    public GameObject LM;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-230, 230), -250, 0);
        //transform.position = new Vector3(0, -250, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 8, 0));
        if (transform.position.y > 400)
        {
            Instantiate(LM);
            Destroy(gameObject);
        }
    }
}

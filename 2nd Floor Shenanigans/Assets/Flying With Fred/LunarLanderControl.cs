using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunarLanderControl : MonoBehaviour
{
    public GameObject LunarAscentModule;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-230, 230), 320, 0);
        //transform.position = new Vector3(0, -250, 0);
        GetComponent<Rigidbody2D>().velocity = new Vector3(Random.Range(-10, 10), -50, 0);
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(0, 1.5f, 0));
        if (transform.position.y < -200)
        {
            Instantiate(LunarAscentModule);
            Destroy(gameObject);
        }
    }
}

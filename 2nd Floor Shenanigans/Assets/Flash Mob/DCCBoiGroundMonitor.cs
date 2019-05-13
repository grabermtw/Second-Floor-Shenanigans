using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCBoiGroundMonitor : MonoBehaviour
{
    private bool touchGround;
    private float count;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        if(count > 6 && rb.velocity.y == 0)
        {
            touchGround = true;
            count = 0;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 12)
        {
            touchGround = true;
        }
        
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == 12)
        {
            touchGround = false;
        }
        
    }

    public bool IsOnGround()
    {
        return touchGround;
    }
}

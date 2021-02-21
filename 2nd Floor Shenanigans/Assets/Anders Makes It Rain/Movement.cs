using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed;

    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(-3.0f, -2.15f, 0.0f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey("right"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (transform.position.x < 9)
            {
                rb.MovePosition(transform.position + Vector3.right * speed * Time.fixedDeltaTime);
            }
        }
        else if (Input.GetKey("left"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (transform.position.x > -9)
            {
                rb.MovePosition(transform.position + Vector3.left * speed * Time.fixedDeltaTime);
            }
        }
    }

    public void IncreaseSpeed()
    {
        speed += 0.13f;
    }

    public void ResetSpeed()
    {
        speed = 0.1f;
    }
}

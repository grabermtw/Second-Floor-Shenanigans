using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 0.1f;

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(-3.0f, -2.15f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("right"))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            if (transform.position.x < 9)
            {
                transform.Translate(Vector3.right * speed);
            }
        }
        else if (Input.GetKey("left"))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            if (transform.position.x > -9)
            {
                transform.Translate(Vector3.left * speed);
            }
        }
	}

    public void IncreaseSpeed()
    {
        speed += 0.0013f;
    }

    public void ResetSpeed()
    {
        speed = 0.1f;
    }
}

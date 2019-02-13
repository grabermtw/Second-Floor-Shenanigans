using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmMovement : MonoBehaviour
{
    public float speed;

    public bool WASD;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!WASD)
        {
            if (Input.GetKey(KeyCode.UpArrow) && transform.position.z < 19)
            {
                transform.position += new Vector3(0, 0, 1 * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && transform.position.z > -1.1f)
            {
                transform.position += new Vector3(0, 0, -1 * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !(transform.position.x < -2.8f && transform.position.z < -.7f)
                && !(transform.position.x < -4 && transform.position.z >= -.7f && transform.position.z < 1)
                && !(transform.position.x < -7 && transform.position.z >= 1))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.position += new Vector3(-1 * speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !(transform.position.x > 2.8f && transform.position.z < -.7f)
                && !(transform.position.x > 4 && transform.position.z >= -.7f && transform.position.z < 1)
                && !(transform.position.x > 8 && transform.position.z >= 1))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                transform.position += new Vector3(1 * speed, 0, 0);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && transform.position.z < 19)
            {
                transform.position += new Vector3(0, 0, 1 * speed);
            }
            if (Input.GetKey(KeyCode.S) && transform.position.z > -1.1f)
            {
                transform.position += new Vector3(0, 0, -1 * speed);
            }
            if (Input.GetKey(KeyCode.A) && !(transform.position.x < -2.8f && transform.position.z < -.7f)
                && !(transform.position.x < -4 && transform.position.z >= -.7f && transform.position.z < 1)
                && !(transform.position.x < -7 && transform.position.z >= 1))
            {
                GetComponent<SpriteRenderer>().flipX = true;
                transform.position += new Vector3(-1 * speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D) && !(transform.position.x > 2.8f && transform.position.z < -.7f)
                && !(transform.position.x > 4 && transform.position.z >= -.7f && transform.position.z < 1)
                && !(transform.position.x > 8 && transform.position.z >= 1))
            {
                GetComponent<SpriteRenderer>().flipX = false;
                transform.position += new Vector3(1 * speed, 0, 0);
            }
        }
    }

    
}

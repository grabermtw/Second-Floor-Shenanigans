using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmMovement : MonoBehaviour
{
    public float speed;

    public bool WASD;

    private SpriteRenderer em;
    private Rigidbody rb;
    private Transform trans;
    
    // Start is called before the first frame update
    void Start()
    {
        em = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody>();
        trans = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newPos = trans.position;
        if (!WASD)
        {
            if (Input.GetKey(KeyCode.UpArrow) && trans.position.z < 19)
            {
                newPos += new Vector3(0, 0, 1 * speed);
            }
            if (Input.GetKey(KeyCode.DownArrow) && trans.position.z > -1.1f)
            {
                newPos += new Vector3(0, 0, -1 * speed);
            }
            if (Input.GetKey(KeyCode.LeftArrow) && !(trans.position.x < -2.8f && trans.position.z < -.7f)
                && !(trans.position.x < -4 && trans.position.z >= -.7f && trans.position.z < 1)
                && !(trans.position.x < -7 && trans.position.z >= 1))
            {
                em.flipX = true;
                newPos += new Vector3(-1 * speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow) && !(trans.position.x > 2.8f && trans.position.z < -.7f)
                && !(trans.position.x > 4 && trans.position.z >= -.7f && trans.position.z < 1)
                && !(trans.position.x > 8 && trans.position.z >= 1))
            {
                em.flipX = false;
                newPos += new Vector3(1 * speed, 0, 0);
            }
            rb.MovePosition(newPos);
        }
        else
        {
            if (Input.GetKey(KeyCode.W) && trans.position.z < 19)
            {
                newPos += new Vector3(0, 0, 1 * speed);
            }
            if (Input.GetKey(KeyCode.S) && trans.position.z > -1.1f)
            {
                newPos += new Vector3(0, 0, -1 * speed);
            }
            if (Input.GetKey(KeyCode.A) && !(trans.position.x < -2.8f && trans.position.z < -.7f)
                && !(trans.position.x < -4 && trans.position.z >= -.7f && trans.position.z < 1)
                && !(trans.position.x < -7 && trans.position.z >= 1))
            {
                em.flipX = true;
                newPos += new Vector3(-1 * speed, 0, 0);
            }
            if (Input.GetKey(KeyCode.D) && !(trans.position.x > 2.8f && trans.position.z < -.7f)
                && !(trans.position.x > 4 && trans.position.z >= -.7f && trans.position.z < 1)
                && !(trans.position.x > 8 && trans.position.z >= 1))
            {
                em.flipX = false;
                newPos += new Vector3(1 * speed, 0, 0);
            }
            rb.MovePosition(newPos);
        }
    }

    
}

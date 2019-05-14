using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DCCEnemyControl : MonoBehaviour
{
    private Rigidbody rb;
    public float spinSpeed;

    private float speed;
    private DCCBoiGroundMonitor groundMonitor;
    
    private bool lying = false;
    private GameObject player;
    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(4f, 6.1f);
        rb = GetComponent<Rigidbody>();
    
        groundMonitor = GetComponentInChildren<DCCBoiGroundMonitor>();
        player = GameObject.FindWithTag("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 relativePos = playerTransform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Quaternion realRot = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        rb.MoveRotation(realRot);

        if (transform.position.z > -270 || System.Math.Abs(Vector3.Distance(playerTransform.position, transform.position)) < 75)
        {
            if (!lying)
            {
                rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);

                if (groundMonitor.IsOnGround() && (Random.Range(0, 170) == 50 || ((System.Math.Abs(rb.velocity.x) < 0.03f && System.Math.Abs(rb.velocity.z) < 0.03f) && Random.Range(0,70) == 25)))
                {
                    rb.AddForce(new Vector3(0, 200, 0));
                    //Debug.Log(gameObject.name + " x velocity: " + rb.velocity.x + " z velocity: " + rb.velocity.z);
                }
            }
        }

    }
}

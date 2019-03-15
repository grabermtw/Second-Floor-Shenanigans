using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCEnemyControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float spinSpeed;

    private DCCBoiGroundMonitor groundMonitor;
    private Vector3 m_EulerAngleVelocity;
    private bool lying = false;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 100, 0);
        groundMonitor = GetComponentInChildren<DCCBoiGroundMonitor>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        Vector3 relativePos = player.GetComponent<Transform>().position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        Quaternion realRot = Quaternion.Euler(0, rotation.eulerAngles.y, 0);
        rb.MoveRotation(realRot);

        if (!lying)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }

    }
}

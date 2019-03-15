

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCPlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public float spinSpeed;
    public GameObject myCamera;

    private DCCBoiGroundMonitor groundMonitor;
    private Vector3 m_EulerAngleVelocity;
    private bool lying = false;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 90, 0);
        groundMonitor = GetComponentInChildren<DCCBoiGroundMonitor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        // Forward
        if (Input.GetKey(KeyCode.W) && !lying)
        {
            rb.MovePosition(transform.position + transform.forward * Time.deltaTime * speed);
        }
        // Backward
        if (Input.GetKey(KeyCode.S) && !lying)
        {
            rb.MovePosition(transform.position - transform.forward * Time.deltaTime * speed);
        }
        // Turn right
        if (Input.GetKey(KeyCode.D) && !lying)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * spinSpeed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        // Turn left
        if (Input.GetKey(KeyCode.A) && !lying)
        {
            Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.deltaTime * -spinSpeed);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }
        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && !lying && groundMonitor.IsOnGround())
        {
            rb.AddForce(new Vector3(0, 200, 0));
        }
        // Lay down
        if (Input.GetKey(KeyCode.X))
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(90,transform.localEulerAngles.y,transform.localEulerAngles.z));
            rb.MoveRotation(deltaRotation);
            lying = true;
           
        }
        else if(transform.localEulerAngles.x > 70 && transform.localEulerAngles.x < 110)
        {
            lying = false;
            rb.MovePosition(transform.position + new Vector3(0,1.5f,0));
            rb.MoveRotation(Quaternion.Euler(0, transform.localEulerAngles.y, 0));
            rb.angularVelocity = new Vector3(0,0,0);
           
        }
    }

    public bool IsLying() {
        return lying;
    }
}

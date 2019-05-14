

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DCCPlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 6;
    public float spinSpeed;


    private Transform cameraTarget;
    private DCCBoiGroundMonitor groundMonitor;
    private Vector3 m_EulerAngleVelocity;
    private bool lying = false;
    private bool caught = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, 90, 0);
        groundMonitor = GetComponentInChildren<DCCBoiGroundMonitor>();
        cameraTarget = GameObject.FindWithTag("Target").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            caught = true;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(90, transform.localEulerAngles.y, transform.localEulerAngles.z));
            rb.MoveRotation(deltaRotation);
            lying = true;
            GameObject.Find("Manager").GetComponent<ScatterPeople>().GameOver(false);
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.layer == 16 && !caught)
        {
            caught = true;
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(90, transform.localEulerAngles.y, transform.localEulerAngles.z));
            rb.MoveRotation(deltaRotation);
            lying = true;
            GameObject.Find("Manager").GetComponent<ScatterPeople>().GameOver(false);
        }
        else if (other.gameObject.CompareTag("Testudo"))
        {
            caught = true;
            GameObject.Find("Manager").GetComponent<ScatterPeople>().GameOver(true);
            cameraTarget.localPosition = new Vector3(0, 1, 4);
        }
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.E))
        {
            cameraTarget.localPosition = new Vector3(0, 1.5f, 4);
        }
        else if (!caught)
        {
            cameraTarget.localPosition = new Vector3(0, 1.5f, -4);
        }

        if (!caught)
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
            if (Input.GetKeyDown(KeyCode.Space) && !lying && (groundMonitor.IsOnGround() || rb.velocity.y == 0))
            {
                rb.AddForce(new Vector3(0, 250, 0));
            }
            // Lay down
            if (Input.GetKey(KeyCode.X))
            {
                Quaternion deltaRotation = Quaternion.Euler(new Vector3(90, transform.localEulerAngles.y, transform.localEulerAngles.z));
                rb.MoveRotation(deltaRotation);
                lying = true;

            }
            else if (transform.localEulerAngles.x > 70 && transform.localEulerAngles.x < 110)
            {
                lying = false;
                rb.MovePosition(transform.position + new Vector3(0, 1.5f, 0));
                rb.MoveRotation(Quaternion.Euler(0, transform.localEulerAngles.y, 0));
                rb.angularVelocity = new Vector3(0, 0, 0);

            }

            if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            {
                rb.angularVelocity = new Vector3(0, 0, 0);
            }
        }
    }

    public bool IsLying() {
        return lying;
    }
}

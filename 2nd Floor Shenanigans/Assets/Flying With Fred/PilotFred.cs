using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PilotFred : MonoBehaviour
{
    
    public GameObject planeImage;
    public GameObject emptyPlaneImage;

    private Rigidbody2D plane;
    // Start is called before the first frame update
    void Start()
    {
        
        plane = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(plane.velocity.x);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            plane.AddForce(new Vector2(30, 0));
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            plane.AddForce(new Vector2(-30, 0));
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
           
            plane.AddForce(new Vector2(0, 30));
 
        }
      
       
        if (Input.GetKey(KeyCode.DownArrow))
        {

            plane.AddForce(new Vector2(0, -30));
        }

        if (plane.velocity.x > 0)
        {
            planeImage.transform.localEulerAngles = new Vector3(0, 0, 0);
            emptyPlaneImage.transform.localEulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            planeImage.transform.localEulerAngles = new Vector3(0, 180, 0);
            emptyPlaneImage.transform.localEulerAngles = new Vector3(0, 180, 0);
        }
        

        if (plane.velocity.y > 30)
        {
            plane.velocity = new Vector2(plane.velocity.x, 30);
        }
        if (plane.velocity.y < -30)
        {
            plane.velocity = new Vector2(plane.velocity.x, -30);
        }
        if (plane.velocity.x > 40)
        {
            plane.velocity = new Vector2(40, plane.velocity.y);
        }
        if (plane.velocity.x < -40)
        {
            plane.velocity = new Vector2(-40, plane.velocity.y);
        }

    }
}

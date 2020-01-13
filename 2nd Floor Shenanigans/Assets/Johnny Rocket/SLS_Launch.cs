using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLS_Launch : MonoBehaviour
{
    private bool launch;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        launch = false;
        rb = GetComponent<Rigidbody>();
    }

    public void BeginLaunch(){
        launch = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(launch){
            rb.AddForce(new Vector3(0,15,0));
           // Debug.Log("launching");
        }
        
    }
}

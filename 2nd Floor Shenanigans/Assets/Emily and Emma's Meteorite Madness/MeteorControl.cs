using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorControl : MonoBehaviour
{
    
    public GameObject Meteorite;
    public GameObject Meteor;

    private float destZ;
    private float destX;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-300, 300), Random.Range(100,200), Random.Range(100, 300));
        destZ = Random.Range(-.5f, 18.5f);
        destX = destZ > 1 ? Random.Range(-7, 8) : Random.Range(-2.8f, 2.8f);
        transform.LookAt(new Vector3(destX, 0, destZ));
        

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 2 && Meteorite.activeSelf == false)
        {
            Meteor.GetComponent<SphereCollider>().enabled = false;
        }
        if (transform.position.y <= 0)
        {
            transform.position = new Vector3(destX, 0, destZ);
            transform.localEulerAngles = new Vector3(0, 0, 0);
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            Destroy(Meteor);
            Meteorite.SetActive(true);
        }
        else
        {
            GetComponent<Rigidbody>().AddRelativeForce(0, 0, 10);
        }
    }
}

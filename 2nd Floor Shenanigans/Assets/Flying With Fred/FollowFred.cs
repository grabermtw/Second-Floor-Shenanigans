using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowFred : MonoBehaviour
{
    public Transform fred;
    public Text warning;
    private bool collided = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SwitchToParachute()
    {
        fred = GameObject.FindGameObjectWithTag("FredParachute").transform;
        collided = true;
    }

    // Update is called once per frame
    void Update()
    {
        bool outX = true;
        bool outY = true;
        if(fred.position.x > 200)
        {
            transform.position = new Vector3(200, transform.position.y, transform.position.z);
        }
        else if(fred.position.x < -200)
        {
            transform.position = new Vector3(-200, transform.position.y, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(fred.position.x, transform.position.y, transform.position.z);
            outX = false;
        }
        if (fred.position.y > 111)
        {
            transform.position = new Vector3(transform.position.x, 111, transform.position.z);
        }
        else if (fred.position.y < -111)
        {
            transform.position = new Vector3(transform.position.x, -111, transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, fred.position.y, transform.position.z);
            outY = false;
        }
        if(outY || outX)
        {
            warning.enabled = true;
        }
        else
        {
            warning.enabled = false;
        }
        if (collided)
        {
            warning.enabled = true;
            warning.text = "GAME OVER\nPress Space to Continue";
        }

    }
}

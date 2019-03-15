using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupMaker : MonoBehaviour
{
    public GameObject[] cuplist;
    public JesseManager manager;

    public Transform myCamera;
    

    private bool ready = false;
    private bool moveRight = false;
    private bool upsidedown = false;
    private bool moveUp = false;
    private float movedUp = 0.0f;
    private int num = 10;
    private float movespeed = 0.15f;
    private float verticalMove = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        NewCups();
    }

    // Update is called once per frame
    void Update()
    {

        if (ready == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropCups();
                transform.position = new Vector3(0, transform.position.y, 0);
                ready = false;
            }

            else if(moveRight)
            {
                transform.position += new Vector3(movespeed, 0, 0);
            }
            else
            {
                transform.position += new Vector3(-movespeed, 0, 0);
            }
            if (transform.position.x > 10)
            {
                moveRight = false;
            }
            else if (transform.position.x < -10)
            {
                moveRight = true;
            }
        }

        if (moveUp == true)
        {
            transform.position += new Vector3(0, 0.03f, 0);
            if (Mathf.Abs(myCamera.position.y - transform.position.y) < 2)
            {
                myCamera.position += new Vector3(0, 0.02f, 0);
            }
            else
            {
                myCamera.position += new Vector3(0, 0.035f, 0);
            }
            movedUp += 0.03f;
            if (movedUp >= verticalMove)
            {
                moveUp = false;
                movedUp = 0.0f;
                NewCups();
            }
        }
    }

    public void DecreaseNum()
    {
        num--;
    }

    public void NewCups()
    {
        if (movespeed < 0.7f)
        {
            movespeed += 0.006f;
        }
        verticalMove -= 0.00217f;
        if (num >= 1)
        {
            for (int i = 0; i < num; i++)
            {
                Instantiate(cuplist[Random.Range(0, cuplist.Length - 1)], transform);
            }
            Rigidbody2D[] myCups = gameObject.GetComponentsInChildren<Rigidbody2D>();
            myCups[0].gameObject.GetComponent<Transform>().position = new Vector3(0, myCups[0].gameObject.GetComponent<Transform>().position.y, 0);
            float xpos = 1.25f;
            int xfact = 0;
            for (int i = 1; i < myCups.Length; i++)
            {
                if (i % 2 != 1)
                {
                    xpos = (-xpos);
                }
                else
                {
                    xfact++;
                    xpos = 1.25f * xfact;
                }
                myCups[i].gameObject.GetComponent<Transform>().position = new Vector3(xpos, myCups[i].gameObject.GetComponent<Transform>().position.y, 0);
            }
            if (upsidedown == true)
            {
                transform.localEulerAngles = new Vector3(0, 0, 180);
                upsidedown = false;
            }
            else
            {
                transform.localEulerAngles = new Vector3(0, 0, 0);
                upsidedown = true;
            }
            transform.position = new Vector3(Random.Range(-9,9), transform.position.y, transform.position.z);
            ready = true;
        }
        else
        {
            manager.GameOver();
            ready = false;
            moveUp = false;
        }
    }

    public void DropCups()
    {
        Rigidbody2D[] myCups = gameObject.GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < myCups.Length; i++)
        {
            myCups[i].bodyType = RigidbodyType2D.Dynamic;
        }
        transform.DetachChildren();
        moveUp = true;
    }
}

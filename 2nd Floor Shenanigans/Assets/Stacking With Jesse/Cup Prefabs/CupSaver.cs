using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupSaver : MonoBehaviour
{
    private Rigidbody2D rb;
    private float initY;
    private bool decreased = false;
    private bool scored = false;
    private bool hit = false;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(initY - transform.position.y) > 2 && decreased == false)
        {
            GameObject.Find("CupManager").GetComponent<CupMaker>().DecreaseNum();
            decreased = true;
        }
        
            
            
            
            
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (hit == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePositionX;
            if (decreased == false && scored == false)
            {
                GameObject.Find("Manager").GetComponent<JesseManager>().AddPoint();
                scored = true;
            }
            GetComponent<AudioSource>().Play();
            hit = true;
        }
    }
}

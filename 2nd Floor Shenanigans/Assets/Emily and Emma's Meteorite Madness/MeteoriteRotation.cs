using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteRotation : MonoBehaviour
{
    public AudioSource ding;
    public GameObject meteorLight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 5, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ding.Play();
            other.gameObject.GetComponent<EmScore>().AddPoint();
            Destroy(meteorLight);
            Destroy(gameObject);
        }
    }
}

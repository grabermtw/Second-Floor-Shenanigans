using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideJohnText : MonoBehaviour
{

    public Transform cinemaCam;
    public AudioSource jupiter;
    public AudioSource disco;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(cinemaCam.position.x >= 343.9f && !disco.isPlaying){
            disco.Play();
            jupiter.Stop();
            GetComponent<MeshRenderer>().enabled = true;
        }
        if(cinemaCam.position.x >= transform.position.x){
            gameObject.SetActive(false);
        }
    }
}

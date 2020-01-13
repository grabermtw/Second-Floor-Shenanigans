using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorControl : MonoBehaviour
{
    private Animator anim;
    public AudioSource laugh;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y < 25){
            anim.SetBool("Grounded", true);
        }
        else{
            anim.SetBool("Grounded", false);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.CompareTag("Player")){
            anim.SetBool("John", true);
            anim.SetFloat("Anim Speed", 1f);
            other.gameObject.transform.SetParent(gameObject.transform);
            if(!laugh.isPlaying){
                laugh.Play();
            }
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.CompareTag("Player")){
            anim.SetBool("John", false);
            anim.SetFloat("Anim Speed", -1f);
            other.gameObject.transform.parent = null;
        }
    }
}

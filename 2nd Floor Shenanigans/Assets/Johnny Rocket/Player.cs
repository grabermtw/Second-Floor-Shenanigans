using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
   // private bool grounded;
    public LaunchTimer timer;
    public LaunchCams launchCams;
    private bool jumped;
    public AudioSource oi;
    public AudioSource laugh2;
    public AudioSource genius;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        oi.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
        animator.SetBool("Kick", Input.GetMouseButtonDown(0));


        if(Input.GetKey(KeyCode.Alpha1)){
            animator.SetInteger("Dance", 1);
        }
        else if (Input.GetKey(KeyCode.Alpha2)){
            animator.SetInteger("Dance",2);
        }
        else if (Input.GetKey(KeyCode.Alpha3)){
            animator.SetInteger("Dance",3);
        }
        else {
            animator.SetInteger("Dance", 0);
        }

        if(Input.GetKey(KeyCode.W) && !animator.GetCurrentAnimatorStateInfo(0).IsName("Headspin Start")
        && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spin Legs Out")
        && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spin Legs In")
        && !animator.GetCurrentAnimatorStateInfo(0).IsName("Spin handstand")){
            if(animator.GetCurrentAnimatorStateInfo(0).IsName("Kick")){
                transform.Translate(0,0, 1f * Time.deltaTime);
            }
            transform.Translate(0,0,4f * Time.deltaTime);
            animator.SetBool("Run", true);
        }
        else{
            animator.SetBool("Run", false);
        }


        if(Input.GetKey(KeyCode.S)){
            if(!animator.GetCurrentAnimatorStateInfo(0).IsName("Kick"))
            transform.Translate(0,0, - 2.75f * Time.deltaTime);
            animator.SetBool("Reverse", true);
        }
        else{
            animator.SetBool("Reverse", false);
        }

       // if(Input.GetKey(KeyCode.Space) && grounded){
       //     animator.SetTrigger("Jump");
       //     rb.AddForce(new Vector3(0,300,0));
       //     grounded = false;
       // }

        if(Input.GetKey(KeyCode.D)){
            transform.Rotate(0,80* Time.deltaTime, 0);
            animator.SetInteger("Turn", 1);
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.Rotate(0,-80* Time.deltaTime, 0);
            animator.SetInteger("Turn", -1);
        }
        else {
            animator.SetInteger("Turn", 0);
        }

        if(Input.GetKey(KeyCode.L)){
            transform.position = new Vector3(64,23,97);
            timer.TwoMin();
        }
    }


    void OnCollisionEnter(Collision other){
        if(other.gameObject.layer == 12){
            rb.isKinematic = true;
            rb.mass = 0;
            rb.useGravity = false;
            animator.SetTrigger("Hang");
            gameObject.transform.parent = other.gameObject.transform;
            launchCams.SetLaunched();
            this.enabled = false;
            genius.Play();

        }
        else{
           // grounded = true;
           jumped = false;
        }
    }

   // void OnCollisionExit(Collision other){
     //   grounded = false;
    //}

    void OnCollisionStay(){
        if(Input.GetKey(KeyCode.Space) && animator != null && !jumped && !animator.GetCurrentAnimatorStateInfo(0).IsName("Jump")){
            animator.SetTrigger("Jump");
            jumped = true;
            rb.AddForce(new Vector3(0,300,0));
            laugh2.Play();
        }
    }


}


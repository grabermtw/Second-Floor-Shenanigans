using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchCameras : StateMachineBehaviour
{
    private GameObject johnCam;
    private GameObject countdown;
    private MouseLook mouseLook;
    private Player player;
    private OpeningSequenceManager manager;
    private AudioSource disco;
    private AudioSource jupiter;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        johnCam = GameObject.FindWithTag("MainCamera");
        countdown = GameObject.FindWithTag("Countdown");
        mouseLook = GameObject.FindWithTag("CamParent").GetComponent<MouseLook>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        manager = GameObject.Find("Manager").GetComponent<OpeningSequenceManager>();
        disco = GameObject.FindWithTag("Disco").GetComponent<AudioSource>();
        jupiter = animator.gameObject.GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(!disco.isPlaying){
            disco.Play();
            jupiter.Stop();
        }
        manager.enabled = false;
        johnCam.GetComponent<Camera>().enabled = true;
        animator.gameObject.GetComponent<Camera>().enabled = false;
        mouseLook.enabled = true;
        player.enabled = true;
        countdown.GetComponent<Text>().enabled = true;
        countdown.GetComponent<LaunchTimer>().enabled = true;
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}

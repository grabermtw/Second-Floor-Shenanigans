using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 
    public float distance;
    public float height;

    private Transform cameraTarget;
    private Transform camTrans;
    private Transform player;
    private DCCPlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        cameraTarget = GameObject.FindWithTag("Target").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        playerControl = player.gameObject.GetComponent<DCCPlayerControl>();
        camTrans = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void LateUpdate()
    {
        if(!playerControl.IsLying())
        camTrans.position = cameraTarget.position;
        camTrans.LookAt(player);
    }

}

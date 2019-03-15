using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
 
    public float distance;
    public float height;
    public Transform cameraTarget;

    private Transform camTrans;
    private Transform player;
    private DCCPlayerControl playerControl;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
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

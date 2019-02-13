using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public SpriteRenderer fredPlane;
    public SpriteRenderer fredlessPlane;
    public GameObject fredParachute;
    public FollowFred fredCam;
    public CdBalloonControl scoreKeeper;
    public FWFGameOverManager gameOverManager;
    public AudioSource crash;

    private bool collided = false;
    private int score;
    private string collideTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (collided)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                gameOverManager.EndGame(score, collideTag);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("collided");
        if (collided == false)
        {
            crash.Play();
            collided = true;
            fredPlane.enabled = false;
            fredlessPlane.enabled = true;
            Instantiate(fredParachute, transform);
            GetComponent<PilotFred>().enabled = false;
            score = scoreKeeper.GetScore();
            collideTag = other.gameObject.tag;
            fredCam.SwitchToParachute(); //something wrong with this in the build
            
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaunchTimer : MonoBehaviour
{
    private Text timerText;
    public float time;
    public GameObject exhaust;
    private bool launched;
    public Animator swingArm;
    public AudioSource disco;

    public GameObject sls;
    public LaunchCams launchCams;
    private Rigidbody slsRb;
    private SLS_Launch launcher;
    private GameObject cam;
    private AudioSource camAudio;

    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        launched = false;
        slsRb = sls.GetComponent<Rigidbody>();
        launcher = sls.GetComponent<SLS_Launch>();
        cam = Camera.main.gameObject;
        camAudio = cam.GetComponent<AudioSource>();
        StartCoundownTimer();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StartCoundownTimer()
 {
     if (timerText != null)
     {
         time = 60*time;
         timerText.text = "T-05:00:000";
         InvokeRepeating("UpdateTimer", 0.0f, 0.01666666667f);
     }
 }

  void UpdateTimer()
 {
     
     if (!launched)
     {
         time -= Time.deltaTime;
         string minutes = Mathf.Floor(time / 60).ToString("00");
         string seconds = (time % 60).ToString("00");
         string fraction = ((time * 100) % 100).ToString("000");
         timerText.text = "T-" + minutes + ":" + seconds + ":" + fraction;
         if(time <= 45){
             swingArm.SetTrigger("Swing");
         }
         if(time <= 6 && !camAudio.isPlaying){
             disco.Stop();
            camAudio.Play();
            exhaust.SetActive(true);
         }
         if(time <= 10){
             slsRb.isKinematic = false;
             launcher.BeginLaunch();
         }
         if(time <= 0){
             launched = true;
             slsRb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ
             | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
             launchCams.SetLaunched();
         }
     }
     else{
         time += Time.deltaTime;
         string minutes = Mathf.Floor(time / 60).ToString("00");
         string seconds = (time % 60).ToString("00");
         string fraction = ((time * 100) % 100).ToString("000");
         timerText.text = "T+" + minutes + ":" + seconds + ":" + fraction;
     }
 }

 public void TwoMin(){
     time = 180;
 }

 
}

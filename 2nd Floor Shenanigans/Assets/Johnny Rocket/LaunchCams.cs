using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCams : MonoBehaviour
{

    private GameObject[] endCams;
    public Camera johnCam;
    public GameObject changeCamText;
    private int current;
    private bool launched;
    // Start is called before the first frame update
    void Start()
    {
        launched = false;
        current = 7;
        endCams = GameObject.FindGameObjectsWithTag("EndCam");
        foreach (GameObject cam in endCams){
            cam.SetActive(false);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(launched && Input.GetKeyDown(KeyCode.C)){
            CycleCam();
        }
    }

    public void SetLaunched(){
        launched = true;
        changeCamText.SetActive(true);
    }

    private void CycleCam(){
        //FIRST
        if(current == 7 && johnCam.enabled){
            johnCam.enabled = false;
            CycleCurr();
            endCams[current].SetActive(true);
            
        }
        else{
            endCams[current].SetActive(false);
            CycleCurr();
            if(current == 7){
                johnCam.enabled = true;
            }
            else{
                endCams[current].SetActive(true);
            }
        }
    }

    private void CycleCurr(){
        if(current == 7){
            current = 0;
        }
        else{
            current++;
        }
        Debug.Log("Current: " + current + " Length of Array: " + endCams.Length);
    }
}

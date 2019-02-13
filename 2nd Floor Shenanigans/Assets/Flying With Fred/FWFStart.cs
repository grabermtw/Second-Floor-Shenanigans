using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FWFStart : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject premiseScreen;
    public GameObject scoreKeeper;
    public GameObject fredPlane;
    public GameObject mainMenuButton;
    private int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && hitCount == 0)
        {
            titleScreen.SetActive(false);
            mainMenuButton.SetActive(false);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            hitCount++;
        }
        if (Input.GetKeyDown(KeyCode.Space) && hitCount > 0)
        {
            premiseScreen.SetActive(false);
            GetComponent<AircraftSpawner>().enabled = true;
            scoreKeeper.SetActive(true);
            fredPlane.SetActive(true);
            this.enabled = false;
        }
    }
}

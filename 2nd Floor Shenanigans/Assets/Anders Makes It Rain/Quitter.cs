using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quitter : MonoBehaviour {

    public HighScoreList highScoreList;
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            highScoreList.Save();
            Application.Quit();
        }
	}

}

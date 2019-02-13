using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NateQuitter : MonoBehaviour {

    public NateHighScoreList highScoreList;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            highScoreList.Save();
            Application.Quit();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GameStart : MonoBehaviour {

    public GameObject title;
    public GameObject instructions;
    public Text scoreText;
    public EdgeCollider2D andersEdge;
    public Movement movement;
    public Destroyer score;
    public GameOver gameOver;

   void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    void Update()
    {
        if (title.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("enter!!!");
                title.SetActive(false);
            }
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !title.activeSelf)
        {
            instructions.SetActive(false);
            GetComponent<Rain>().enabled = true;
            scoreText.enabled = true;
            movement.enabled = true;
            gameOver.enabled = true;
            andersEdge.enabled = true;
            score.ResetScore();
            enabled = false;
            
        }
    }
	
}

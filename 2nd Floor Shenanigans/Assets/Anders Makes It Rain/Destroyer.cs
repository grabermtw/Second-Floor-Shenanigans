using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destroyer : MonoBehaviour {

    public AudioSource ding;
    public Text scoreText;
    public GameOver gameOver;
    public Movement movementSpeed;

    private int score = 0;

    public void ResetScore()
    {
        score = 0;
        scoreText.text = "Score: 0";
    }

	void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        
        movementSpeed.IncreaseSpeed();

        if (!gameOver.IsGameOver())
        {
            score++;
            scoreText.text = "Score: " + score;
            ding.Play();
        }
    }

    public int GetScore()
    {
        return score;
        
    }


}

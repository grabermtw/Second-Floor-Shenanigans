using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public AudioSource dontLike;
    public AudioSource insane;
    public Rain rain;
    public GameObject endScreen;
    public Text scoreText;
    public Text finalScore;
    public Text highScore;
    public Destroyer score;
    public GameObject title;
    public GameObject instructions;
    public GameStart gameStart;
    public HighScoreList highScoreList;
    public Text highScoreListText;
    public GameObject nameInput;
    public Movement speed;
    public GameObject mainMenuButton;
    public GameObject gameOverMessage;

    private bool gameOver = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("GameController"))
        {
            if (Random.Range(0, 10) > 5)
            {
                insane.Play();
            }
            else
            {
                dontLike.Play();
            }
            GetComponent<Rigidbody2D>().gravityScale = 0.1f;
            GetComponent<Movement>().enabled = false;
            gameOverMessage.SetActive(true);
            gameOver = true;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameOverMessage.activeSelf)
        {
            gameOverMessage.SetActive(false);
            EndTheGame();
        }
    }

    private void EndTheGame() {
        rain.enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
        endScreen.SetActive(true);
        scoreText.text = "Score: ";
        scoreText.enabled = false;
        finalScore.enabled = true;
        finalScore.text = "" + score.GetScore();
        highScore.enabled = true;
        highScoreListText.enabled = true;
        mainMenuButton.SetActive(true);
        nameInput.SetActive(true);


        highScore.text = score.GetScore() > highScoreList.GetHighScore() ? score.GetScore() + " Nice!"
            : "" + highScoreList.GetHighScore();

        Debug.Log(highScoreList.ToString());
        highScoreListText.text = highScoreList.ToString();

        gameOver = true;
    }

    //private void Update()
    //{
    //    if(gameOver && Input.GetKey(KeyCode.Space))
    //    {
    //        instructions.SetActive(true);
    //        title.SetActive(true);
    //        endScreen.SetActive(false);
    //        finalScore.enabled = false;
    //        gameStart.enabled = true;
    //        highScore.enabled = false;
    //        highScoreListText.enabled = false;
    //        nameInput.SetActive(false);
    //        gameOver = false;
    //        enabled = false;
    //    }
    //}

    public void NameInputFinish()
    {
        string name = nameInput.GetComponent<InputField>().text;
        Debug.Log(name);
        highScoreList.AddScore(score.GetScore(), name);
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");

        //Not doing this crap anymore cause I figured out how to reload the scene:

        //nameInput.GetComponent<InputField>().text = "";
        //instructions.SetActive(true);
        //speed.ResetSpeed();
        //title.SetActive(true);
        //rain.ResetPeriod();
        //endScreen.SetActive(false);
        //finalScore.enabled = false;
        //gameStart.enabled = true;
        //highScore.enabled = false;
        //highScoreListText.enabled = false;
        //nameInput.SetActive(false);
        //gameOver = false;
        //enabled = false;

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public bool IsGameOver()
    {
        return gameOver;
    }

    public void ReturnMainMenu()
    {
        highScoreList.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }


}

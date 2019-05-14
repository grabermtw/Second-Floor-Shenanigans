using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScatterPeople : MonoBehaviour
{
    public GameObject[] mobsters;
    public GameObject mob;
    public GameObject characterSelect;
    public Text timerText;
    public Text gameOverText;
    public GameObject winScreen;
    public GameObject loseScreen;
    public MobHighScores highScoresList;
    public Text highScoreListText;
    public Text endTimeText;
    public InputField nameInput;

    private float startTime;
    private bool gameOver = false;
    private float timeElapsed;
    private bool winner = false;
    private float gameoverTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameoverTime += Time.deltaTime;
        }
        if (!gameOver && !characterSelect.activeSelf)
        {
            timeElapsed = Time.time - startTime;
            string minutes = ((int)timeElapsed / 60).ToString();
            string seconds = (timeElapsed % 60).ToString("f2");
            timerText.text = "Time: " + minutes + ":" + seconds;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !characterSelect.activeSelf && gameoverTime > 1.5f)
        {
            mob.SetActive(false);
            highScoreListText.enabled = true;
            highScoreListText.text = highScoresList.ToString();
            if (winner)
            {
                winScreen.SetActive(true);
                string minutes = ((int)timeElapsed / 60).ToString();
                string seconds = (timeElapsed % 60).ToString("f2");
                endTimeText.text = "Your Time: " + minutes + ":" + seconds;
            }
            else
            {
                loseScreen.SetActive(true);
            }
        } 
    }

    public void NameInputFinish()
    {
        string name = nameInput.text;
        Debug.Log(name);
        highScoresList.AddScore(timeElapsed, name);
        highScoresList.AddScore(100000, "");
        highScoresList.AddScore(100000, "");
        highScoresList.Save();

        GetComponent<MobQuitter>().RestartScene();
    }

    public void ReturnMainMenu()
    {
        highScoresList.Save();
        GetComponent<MobQuitter>().MainMenuReturn();
    }


    public void GameOver(bool win)
    {
        Debug.Log("GAME OVER");
        winner = win;
        gameOverText.gameObject.SetActive(true);
        gameOver = true;
        

        if (win)
        {
            gameOverText.text = "Congratulations! You have reached Testudo!";
        }
        else
        {
            gameOverText.text = "Oh no! You have been caught!";
        }
    }


    public void InstantiatePlayer(int playerIndex)
    {
        characterSelect.SetActive(false);
        Quaternion rot = Quaternion.Euler(0, 180, 0);
        Instantiate(mobsters[playerIndex], new Vector3(0, 5.5f, 92), rot);
        Camera.main.gameObject.GetComponent<FollowPlayer>().enabled = true;
        startTime = Time.time;
        timerText.enabled = true;
    }


    public void Scatter(string player)
    {
        mob.SetActive(true);
        Rigidbody[] people = mob.GetComponentsInChildren<Rigidbody>();
        
        foreach(Rigidbody rb in people)
        {
            if (rb.gameObject.CompareTag(player)){
                rb.gameObject.SetActive(false);
            }
            else
            {
                rb.gameObject.transform.position = new Vector3(Random.Range(-64, 62), 16.5f, Random.Range(-300, 72));
            }
        }
    }
}

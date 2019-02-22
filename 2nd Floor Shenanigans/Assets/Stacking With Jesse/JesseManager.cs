using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JesseManager : MonoBehaviour
{
    public Transform mainCamera;
    public GameObject jesseGameOverBent;
    public GameObject titleScreen;
    public GameObject instructions;
    public GameObject endScreen;
    public GameObject scoreKeeper;
    public GameObject gameOverMessage;
    public GameObject cupManager;
    public GameObject mainMenuButton;

    public JesseHighScores highScoreList;

    public GameObject endUI;
    public InputField nameInput;
    public Text highScoreText;
    public Text endText;
    public GameObject jesses;

    private SpriteRenderer[] jesseImages;
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        jesseImages = jesses.GetComponentsInChildren<SpriteRenderer>(true);
        Debug.Log("HEYYY there are " + jesseImages.Length);
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(titleScreen.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            titleScreen.SetActive(false);
            mainMenuButton.SetActive(false);
            instructions.SetActive(true);
            GetJesses();
        }
        else if(instructions.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            instructions.SetActive(false);
            scoreKeeper.SetActive(true);
            cupManager.SetActive(true);
            
        }
        else if(gameOverMessage.activeSelf == true && Input.GetKeyDown(KeyCode.Space))
        {
            jesseGameOverBent.SetActive(false);
            scoreKeeper.SetActive(false);
            gameOverMessage.SetActive(false);
            endScreen.SetActive(true);
            endUI.SetActive(true);
            highScoreText.text = highScoreList.ToString();
            endText.text = "You stacked " + score + " cups with Jesse!";
            mainCamera.position = new Vector3(0, 0, -10);
        }
    }

    public void NameInputFinish()
    {
        string name = nameInput.text;
        Debug.Log(name);
        highScoreList.AddScore(score, name);
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");
        highScoreList.Save();

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ReturnMainMenu()
    {
        highScoreList.Save();
        GetComponent<OmerQuitter>().MainMenuReturn();
    }

    private void GetJesses()
    {
        for(int i = 0; i < jesseImages.Length; i++)
        {
            if(Random.Range(0,10) > 5)
            {
                Debug.Log(jesseImages[i].gameObject.name);
                jesseImages[i].gameObject.SetActive(true);
            }
        }
    }

    public void AddPoint()
    {
        score++;
        if (score == 1)
        {
            scoreKeeper.GetComponent<Text>().text = score.ToString() + " Cups Stacked";
        }
        else
        {
            scoreKeeper.GetComponent<Text>().text = score.ToString() + " Cups Stacked";
        }
     //   Debug.Log(score);
    }

    public void GameOver()
    {
        gameOverMessage.SetActive(true);
        jesseGameOverBent.SetActive(true);
        cupManager.SetActive(false);
    }
}

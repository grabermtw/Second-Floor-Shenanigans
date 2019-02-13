using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FWFGameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject nameInput;
    public GameObject cdsCollected;
    public GameObject highScoresListText;
    public GameObject gameOverText;
    public GameObject endText;
    public GameObject mainCamera;
    public GameObject mainMenuButton;

    private FredHighScoresList highScoreList;
    private int finalScore;
    
    // Start is called before the first frame update
    void Start()
    {
        highScoreList = GetComponent<FredHighScoresList>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndGame(int score, string tag)
    {
        cdsCollected.SetActive(false);
        gameOverText.SetActive(false);
        GetComponent<AircraftSpawner>().enabled = false;
        mainCamera.GetComponent<FollowFred>().enabled = false;
        mainCamera.transform.position = new Vector3(0, 0, -10);

        finalScore = score;
        mainMenuButton.SetActive(true);
        gameOverScreen.SetActive(true);
        nameInput.SetActive(true);
        highScoresListText.SetActive(true);
        highScoresListText.GetComponent<Text>().text = highScoreList.ToString();
        endText.SetActive(true);

        endText.GetComponent<Text>().text = "You collected " + score + " CDs before colliding with " + tag + "!";
    }
    

    public void NameInputFinish()
    {
        string name = nameInput.GetComponent<InputField>().text;
        Debug.Log(name);
        highScoreList.AddScore(finalScore, name);
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}

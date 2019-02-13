using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EmMenuManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject singlePlayerInstructions;
    public GameObject chooseCharacterScreen;
    public GameObject twoPlayerInstructions;
    public GameObject emilySingleGameOverScreen;
    public GameObject emmaSingleGameOverScreen;
    public GameObject emilyWinsScreen;
    public GameObject emmaWinsScreen;

    public GameObject emily;
    public GameObject emma;

    public GameObject emmaP1Text;
    public GameObject emilyP2Text;
    public GameObject mainMenuButtons;
    public GameObject characterButtons;
    public GameObject gameOverText;
    public GameObject highScoreListText;
    public GameObject endScoreText;
    public GameObject nameInputField;
    

    public GameObject arena;

    private bool mainMenu = true;
    private bool twoPlayer = false;
    private bool emilyPlayer = false;
    private bool gameOver = false;
    private bool emmaWins = false;
    private bool emilyWins = false;
    private bool p2setUp = false;

    private int finalScore;

    private EmHighScoreList highScoreList;

    // Start is called before the first frame update
    void Start()
    {
        highScoreList = GetComponent<EmHighScoreList>();
    }

    // Update is called once per frame
    void Update()
    {
        //Multiplayer
        if (twoPlayer)
        {
            if (!p2setUp && Input.GetKeyDown(KeyCode.Space))
            {
                twoPlayerInstructions.SetActive(false);
                p2setUp = true;
                arena.SetActive(true);
                
                emma.SetActive(true);
                emmaP1Text.SetActive(true);
                emily.SetActive(true);
                emilyP2Text.SetActive(true);
                GetComponent<MeteorSpawner>().enabled = true;
            }
            else if (emilyWins)
            {
                if (emilyWinsScreen.activeSelf == false)
                {
                    gameOverText.SetActive(true);
                }
                if (emilyWinsScreen.activeSelf == false && Input.GetKeyDown(KeyCode.Space))
                {
                    gameOverText.SetActive(false);
                    emmaP1Text.SetActive(false);
                    emilyP2Text.SetActive(false);
                    emilyWinsScreen.SetActive(true);
                    GetComponent<MeteorSpawner>().enabled = false;
                    arena.SetActive(false);
                    emily.SetActive(false);
                    emma.SetActive(false);
                    ClearMeteorites();
                }
                else if (emilyWinsScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
            }
            else if (emmaWins)
            {
                if (emmaWinsScreen.activeSelf == false)
                {
                    gameOverText.SetActive(true);
                }
                if (emmaWinsScreen.activeSelf == false && Input.GetKeyDown(KeyCode.Space))
                {
                
                    gameOverText.SetActive(false);
                    emmaWinsScreen.SetActive(true);
                    emmaP1Text.SetActive(false);
                    emilyP2Text.SetActive(false);
                    GetComponent<MeteorSpawner>().enabled = false;
                    arena.SetActive(false);
                    emily.SetActive(false);
                    emma.SetActive(false);
                    ClearMeteorites();
                }
                else if (emmaWinsScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
                {
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);
                }
            }
        }
        //Single Player
        else if(!mainMenu)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                singlePlayerInstructions.SetActive(false);
                chooseCharacterScreen.SetActive(true);
                characterButtons.SetActive(true);
                mainMenu = true;
            }
        }
        else if (emilyPlayer && gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOverText.SetActive(false);
                emilyP2Text.SetActive(false);
                emilySingleGameOverScreen.SetActive(true);
                EndGame();
                
            }
        }
        else if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameOverText.SetActive(false);
                emmaP1Text.SetActive(false);
                emmaSingleGameOverScreen.SetActive(true);
                EndGame();

            }
        }
    }

    public void OnePlayer()
    {
        titleScreen.SetActive(false);
        mainMenu = false;
        mainMenuButtons.SetActive(false);
        singlePlayerInstructions.SetActive(true);
    }

    public void TwoPlayers()
    {
        titleScreen.SetActive(false);
        //mainMenu = false;
        twoPlayer = true;
        mainMenuButtons.SetActive(false);
        twoPlayerInstructions.SetActive(true);
    }

    public void StartEmily()
    {
        emilyPlayer = true;
        chooseCharacterScreen.SetActive(false);
        characterButtons.SetActive(false);
        arena.SetActive(true);
        emily.SetActive(true);
        emilyP2Text.SetActive(true);
        GetComponent<MeteorSpawner>().enabled = true;
    }

    public void StartEmma()
    {
        chooseCharacterScreen.SetActive(false);
        characterButtons.SetActive(false);
        arena.SetActive(true);
        emma.SetActive(true);
        emma.GetComponent<EmMovement>().WASD = false;
        emmaP1Text.SetActive(true);
        GetComponent<MeteorSpawner>().enabled = true;
    }

    public void EndEm(int score)
    {
        finalScore = score;
        gameOver = true;
        gameOverText.SetActive(true);
    }

    

    public void EmilyKilled2P()
    {
        if (!emilyWins) {
            emmaWins = true;
        }
    }
    public void EmmaKilled2P()
    {
        if (!emmaWins) { 
            emilyWins = true;
        }
    }

    public void EndGame()
    {
        
        highScoreListText.SetActive(true);
        endScoreText.SetActive(true);
        nameInputField.SetActive(true);

        GetComponent<MeteorSpawner>().enabled = false;
        arena.SetActive(false);
        emily.SetActive(false);
        emma.SetActive(false);
        emmaP1Text.SetActive(false);
        emilyP2Text.SetActive(false);

        ClearMeteorites();

        highScoreListText.GetComponent<Text>().text = highScoreList.ToString();
        if (finalScore != 1)
        {
            endScoreText.GetComponent<Text>().text = "You collected " + finalScore + " meteorites!";
        }
        else
        {
            endScoreText.GetComponent<Text>().text = "You collected 1 meteorite!";
        }
    }


    public void NameInputFinish()
    {
        string name = nameInputField.GetComponent<InputField>().text;
        Debug.Log(name);
        highScoreList.AddScore(finalScore, name);
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void ReturnMainMenu()
    {
        highScoreList.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    private void ClearMeteorites()
    {
        GameObject[] condemned = GameObject.FindGameObjectsWithTag("meteor");
        foreach(GameObject obj in condemned)
        {
            Destroy(obj);
        }
    }
}

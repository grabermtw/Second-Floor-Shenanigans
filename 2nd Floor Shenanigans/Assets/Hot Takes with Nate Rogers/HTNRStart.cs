using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HTNRStart : MonoBehaviour {

    public GameObject title;
    public GameObject instructions;
    public GameObject instructions2;
    public GameObject gameBackground;
    public GameObject nateTakeGiver;
    public GameObject nateTakeBox;
    public Text nateTakeBoxText;
    public Text nateSmallTakeBoxText;
    public GameObject takeBoxes;
    public Text leftTake;
    public Text rightTake;
    public HotTakeGenerator generator;
    public GameObject nateThumbsUp;
    public GameObject scoreBox;
    public Text scoreText;
    public GameObject EndScreen;
    public NateHighScoreList highScoreList;
    public GameObject nateHot;
    public GameObject nateCold;
    public GameObject nateAmbient;
    public GameObject nextButton;

    public GameObject finalScoreTexts;
    public Text finalScoreText;
    public Text highScoreText;
    public Text highScoresListText;

    public GameObject nameInput;
    public GameObject mainMenuReturn;

    public GameObject livesPanel;
    public GameObject[] livesIcons;

    public GameObject[] hotResponses;
    public GameObject[] coldResponses;
    public GameObject tieResponse;

    public AudioSource ding;
    public AudioSource woosh;
    public AudioSource fire;

    static int TakeNumber = 0;
    static int score = 0;
    static int lifeReduction = 0;

    static int leftTakeValue;
    static int rightTakeValue;

    private bool canGetTakes = true;

    private SortedList<int, string> hotCategories = new SortedList<int, string>(new DuplicateKeyComparer<int>());
    

	// Use this for initialization
	void Start () {
        fire.Play();
        finalScoreTexts.SetActive(false);
        EndScreen.SetActive(false);
        livesPanel.SetActive(false);
        title.SetActive(true);
        scoreBox.SetActive(false);
        instructions.SetActive(false);
        instructions2.SetActive(false);
        gameBackground.SetActive(false);
        generator.SetCategoryValues();
        nameInput.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && title.activeSelf)
        {
            fire.Stop();
            title.SetActive(false);
            instructions.SetActive(true);
            mainMenuReturn.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Space) && !title.activeSelf && instructions.activeSelf)
        {
            instructions.SetActive(false);
            instructions2.SetActive(true);
            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && !title.activeSelf && instructions2.activeSelf)
        {
            instructions2.SetActive(false);
            gameBackground.SetActive(true);
            scoreBox.SetActive(true);
            livesPanel.SetActive(true);
            GetTakes(0);
            
        }

    }

    private string SortCategoriesByHeat()
    {
        string sortedCategories = "Today's Hottest Categories, Ranked:\n";
        generator.SetCategoryValues();
        int[] catValues = generator.GetCategoryValues();

        hotCategories.Clear();

        hotCategories.Add(catValues[0], "DCC Second Floor");
        hotCategories.Add(catValues[1], "DCC Third Floor");
        hotCategories.Add(catValues[2], "DCC Faculty");
        hotCategories.Add(catValues[3], "DCC");
        hotCategories.Add(catValues[4], "UMD");
        hotCategories.Add(catValues[5], "UMD Faculty");
        hotCategories.Add(catValues[6], "Physics");
        hotCategories.Add(catValues[7], "Computer Science");
        hotCategories.Add(catValues[8], "Academics");
        hotCategories.Add(catValues[9], "Music");
        hotCategories.Add(catValues[10], "Sports");
        hotCategories.Add(catValues[11], "Engineering");

        List < String > sortedCatStrings = new List<string>(hotCategories.Values);
        sortedCatStrings.Reverse();
       // List<int> sortedCatInts = new List<int>(hotCategories.Keys);
       // sortedCatInts.Reverse();
        for(int i = 0; i < hotCategories.Count; i++)
        {
            sortedCategories += (i + 1) + ". " + sortedCatStrings[i] + "\n";
        }
        return sortedCategories;

    }

    public void GetTakes(int takeSide)
    {
        if (canGetTakes)
        {
            nateAmbient.SetActive(false);
            //correct
            if ((takeSide == 1 && leftTakeValue > rightTakeValue) || (takeSide == 2 && leftTakeValue < rightTakeValue))
            {
                score++;
                scoreText.text = "Score: " + score;
                nateHot.SetActive(true);
                hotResponses[UnityEngine.Random.Range(0, hotResponses.Length - 1)].SetActive(true);
                ding.Play();
            }
            //tie, no score increase
            else if (leftTakeValue == rightTakeValue)
            {
                Debug.Log("Tie");
                tieResponse.SetActive(true);
                nateThumbsUp.SetActive(true);
            }
            //loss
            else if (takeSide == 1 || takeSide == 2)
            {
                lifeReduction++;
                coldResponses[UnityEngine.Random.Range(0, coldResponses.Length - 1)].SetActive(true);
                nateCold.SetActive(true);
                woosh.Play();
            }
            // decrease life
            for (int i = 0; i < lifeReduction; i++)
            {
                livesIcons[i].SetActive(false);
            }
            // Activate Sassy Nate and "next button"
            nextButton.SetActive(true);
            canGetTakes = false;
            if (takeSide == 0)
            {
                NextButton();
            }
        }
    }



    public void NextButton()
    {
        foreach(GameObject obj in coldResponses)
        {
            obj.SetActive(false);
        }
        foreach (GameObject obj in hotResponses)
        {
            obj.SetActive(false);
        }
        tieResponse.SetActive(false);
        if (lifeReduction >= 5)
        {
            endGame();
            return;
        }
        if (TakeNumber >= 5)
        {
            TakeNumber = 0;
        }
        if (TakeNumber < 1)
        {
            nextButton.SetActive(false);
            nateTakeGiver.SetActive(true);
            nateTakeBox.SetActive(true);
            takeBoxes.SetActive(false);
            nateThumbsUp.SetActive(false);
            nateAmbient.SetActive(false);
            nateCold.SetActive(false);
            nateHot.SetActive(false);
            string sortedTakes = SortCategoriesByHeat();
            nateTakeBoxText.text = sortedTakes;
            nateSmallTakeBoxText.text = sortedTakes;
            TakeNumber++;
            canGetTakes = true;
        }
        else
        {
            nextButton.SetActive(false);
            nateTakeBox.SetActive(false);
            nateTakeGiver.SetActive(false);
            takeBoxes.SetActive(true);
            nateThumbsUp.SetActive(false);
            nateAmbient.SetActive(true);
            nateCold.SetActive(false);
            nateHot.SetActive(false);


            HotTakeGenerator.HotTake left = generator.Generate();
            HotTakeGenerator.HotTake right = generator.Generate();
            rightTakeValue = right.GetValue();
            leftTakeValue = left.GetValue();
            Debug.Log(left.GetText() + " value: " + left.GetValue());
            Debug.Log(right.GetText() + " value: " + right.GetValue());
            leftTake.text = left.GetText();
            rightTake.text = right.GetText();
            TakeNumber++;
            canGetTakes = true;
        }
    }


    public void endGame()
    {
        foreach (GameObject obj in coldResponses)
        {
            obj.SetActive(false);
        }
        fire.Play();
        nateCold.SetActive(false);
        EndScreen.SetActive(true);
        finalScoreTexts.SetActive(true);
        highScoresListText.text = highScoreList.ToString();
        finalScoreText.text = "" + score;
        highScoreText.text = score > highScoreList.GetHighScore() ? score + " Nice!"
            : "" + highScoreList.GetHighScore();

        Debug.Log(highScoreList.ToString());

        mainMenuReturn.SetActive(true);
        gameBackground.SetActive(false);
        takeBoxes.SetActive(false);
        scoreBox.SetActive(false);
        livesPanel.SetActive(false);
        nateThumbsUp.SetActive(false);
        nameInput.SetActive(true);
    }

    public void nameInputFinish()
    {
        string name = nameInput.GetComponent<InputField>().text;
        highScoreList.AddScore(score, name);
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");
        highScoreList.AddScore(0, "");

        Debug.Log(score + " " + name);
        score = 0;
        lifeReduction = 0;
        TakeNumber = 0;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    public void ReturnMainMenu()
    {
        score = 0;
        lifeReduction = 0;
        TakeNumber = 0;
        highScoreList.Save();
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

    /// <summary>
    /// Comparer for comparing two keys, handling equality as beeing greater
    /// Use this Comparer e.g. with SortedLists or SortedDictionaries, that don't allow duplicate keys
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class DuplicateKeyComparer<TKey>
                    :
                 IComparer<TKey> where TKey : IComparable
    {
        #region IComparer<TKey> Members

        public int Compare(TKey x, TKey y)
        {
            int result = x.CompareTo(y);

            if (result == 0)
                return 1;   // Handle equality as beeing greater
            else
                return result;
        }

        #endregion
    }
}

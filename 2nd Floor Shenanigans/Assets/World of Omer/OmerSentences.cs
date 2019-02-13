using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OmerSentences : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject instruction;
    public GameObject mainMenuButton;
    public GameObject endMainMenuButton;
    public GameObject canvasGameplay;

    public GameObject omerNeutral;
    public GameObject omerPleased;
    public GameObject omerDisappointed;
    public GameObject map;

    public GameObject nextButton;
    

    public Text choice1;
    public Text choice2;
    public Text choice3;
    public Text choice4;
    public Text omersMessage;
    public Text languageIndicator;
    public Text scoreText;

    public GameObject[] lifeIcons;

    public GameObject inputField;
    public GameObject gameOverScreen;
    public Text highScoreText;
    public Text endScoreText;

    public AudioSource[] badAnswerAudio;

    private Translate translator;
    private HotTakeGenerator generator;

    private string translation;
    private string correctSentence;
    private int correctChoice;
    private string translatedLanguage;

    private int score = 0;

    private OmerHighScores highScoreList;

    //life[0] should be rightmost life
    private int lives = 5;

    private List<Language> languages;

    private bool nextActivated = false;

    public class Language
    {
        private string ISOcode;
        private string langName;
        public Language(string langName, string ISOcode)
        {
            this.ISOcode = ISOcode;
            this.langName = langName;
        }

        public string GetISO()
        {
            return ISOcode;
        }

        public string GetName()
        {
            return langName;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        highScoreList = GetComponent<OmerHighScores>();
        endScoreText.enabled = false;
        highScoreText.enabled = false;
        translator = GetComponent<Translate>();
        generator = GetComponent<HotTakeGenerator>();

        // Populate the languages list:
        {
            languages = new List<Language>();

            languages.Add(new Language("Afrikaans", "af"));
            languages.Add(new Language("Albanian", "sq"));
            languages.Add(new Language("Arabic", "ar"));
            languages.Add(new Language("Armenian", "hy"));
            languages.Add(new Language("Azerbaijani", "az"));
            languages.Add(new Language("Basque", "eu"));
            languages.Add(new Language("Belarusian", "be"));
            languages.Add(new Language("Bengali", "bn"));
            languages.Add(new Language("Bosnian", "bs"));
            languages.Add(new Language("Bulgarian", "bg"));
            languages.Add(new Language("Catalan", "ca"));
            languages.Add(new Language("Chinese", "zh"));
            languages.Add(new Language("Croatian", "hr"));
            languages.Add(new Language("Czech", "cs"));
            languages.Add(new Language("Danish", "da"));
            languages.Add(new Language("Esperanto", "eo"));
            languages.Add(new Language("Estonian", "et"));
            languages.Add(new Language("Finnish", "fi"));
            languages.Add(new Language("French", "fr"));
            languages.Add(new Language("Galician", "gl"));
            languages.Add(new Language("Georgian", "ka"));
            languages.Add(new Language("German", "de"));
            languages.Add(new Language("Greek", "el"));
            languages.Add(new Language("Hatian Creole", "ht"));
            languages.Add(new Language("Hebrew", "he"));
            languages.Add(new Language("Hindi", "hi"));
            languages.Add(new Language("Hungarian", "hu"));
            languages.Add(new Language("Icelandic", "is"));
            languages.Add(new Language("Indonesian", "id"));
            languages.Add(new Language("Irish", "ga"));
            languages.Add(new Language("Italian", "it"));
            languages.Add(new Language("Japanese", "ja"));
            languages.Add(new Language("Javanese", "jv"));
            languages.Add(new Language("Kannada", "kn"));
            languages.Add(new Language("Kazakh", "kk"));
            languages.Add(new Language("Korean", "ko"));
            languages.Add(new Language("Kyrgyz", "ky"));
            languages.Add(new Language("Lao", "lo"));
            languages.Add(new Language("Latin", "la"));
            languages.Add(new Language("Latvian", "lv"));
            languages.Add(new Language("Lithuanian", "lt"));
            languages.Add(new Language("Luxembourgish", "lb"));
            languages.Add(new Language("Macedonian", "mk"));
            languages.Add(new Language("Malagasy", "mg"));
            languages.Add(new Language("Malay", "ms"));
            languages.Add(new Language("Malayalam", "ml"));
            languages.Add(new Language("Maltese", "mt"));
            languages.Add(new Language("Maori", "mi"));
            languages.Add(new Language("Marathi", "mr"));
            languages.Add(new Language("Mongolian", "mn"));
            languages.Add(new Language("Nepali", "ne"));
            languages.Add(new Language("Norwegian", "no"));
            languages.Add(new Language("Persian", "fa"));
            languages.Add(new Language("Polish", "pl"));
            languages.Add(new Language("Portuguese", "pt"));
            languages.Add(new Language("Punjabi", "pa"));
            languages.Add(new Language("Romanian", "ro"));
            languages.Add(new Language("Russian", "ru"));
            languages.Add(new Language("Scottish", "gd"));
            languages.Add(new Language("Serbian", "sr"));
            languages.Add(new Language("Slovakian", "sk"));
            languages.Add(new Language("Slovenian", "sl"));
            languages.Add(new Language("Spanish", "es"));
            languages.Add(new Language("Swahili", "sw"));
            languages.Add(new Language("Swedish", "sv"));
            languages.Add(new Language("Tagalog", "tl"));
            languages.Add(new Language("Tajik", "tg"));
            languages.Add(new Language("Tamil", "ta"));
            languages.Add(new Language("Telugu", "te"));
            languages.Add(new Language("Thai", "th"));
            languages.Add(new Language("Turkish", "tr"));
            languages.Add(new Language("Ukranian", "uk"));
            languages.Add(new Language("Urdu", "ur"));
            languages.Add(new Language("Uzbek", "uz"));
            languages.Add(new Language("Vietnamese", "vi"));
            languages.Add(new Language("Welsh", "cy"));
            languages.Add(new Language("Xhosa", "xh"));
            languages.Add(new Language("Yiddish", "yi"));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(titleScreen.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            titleScreen.SetActive(false);
            mainMenuButton.SetActive(false);
            instruction.SetActive(true);
        }
        else if(instruction.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            instruction.SetActive(false);
            canvasGameplay.SetActive(true);
            omerNeutral.SetActive(true);
            map.SetActive(true);
            GetAllSentences();
        }
    }

    //This is called automatically by the translator when the translation is finished
    public void ReceiveTranslation(string result)
    {
        Debug.Log("Omer's message for you: " + result);
        translation = result;
        omersMessage.text = "\"" + translation + "\"";
    }


    //Call this first
    private void GetAllSentences()
    {
        string[] answers;
        omersMessage.text = "I'm thinking....";

        if (score > 4)
        {
            answers = generator.GetOmerSentences();
        }
        else
        {
            answers = new string[4];
            for (int i = 0; i < 4; i++)
            {
                answers[i] = generator.Generate().GetText();
            }
        }

        correctChoice = Random.Range(0, 3);

        choice1.text = answers[0];
        choice2.text = answers[1];
        choice3.text = answers[2];
        choice4.text = answers[3];

        correctSentence = answers[correctChoice];
         
        translator.GetTranslation(GetLanguage(), answers[correctChoice]);

        languageIndicator.text = translatedLanguage;
       // At this point we have a randomly ordered string array with one correct answer and three wrong answers, and the translation is being got.

        //Debug:
        foreach(string sentence in answers)
        {
            Debug.Log(sentence);
        }
    }

    private string GetLanguage()
    {
        Language lang = languages[Random.Range(0, languages.Count)];
        translatedLanguage = lang.GetName();
        Debug.Log(translatedLanguage);
        return lang.GetISO();
    }

    public void Answer(int choice)
    {
        if (!nextActivated)
        {
            nextActivated = true;
            omerNeutral.SetActive(false);
            if (choice == correctChoice)
            {
                omerPleased.SetActive(true);
                omersMessage.text = "You are correct!";
                nextButton.SetActive(true);
                score++;
                scoreText.text = "Score: " + score;
                GetComponent<AudioSource>().Play();
            }
            else
            {
                omerDisappointed.SetActive(true);
                omersMessage.text = "No! I said \"" + correctSentence + "\"";
                lives--;
                UpdateLives();
                nextButton.SetActive(true);
                badAnswerAudio[Random.Range(0, badAnswerAudio.Length - 1)].Play();
            }
        }
    }

    private void UpdateLives()
    {
        if(lives == 4)
        {
            lifeIcons[0].SetActive(false);
        }
        else if(lives == 3)
        {
            lifeIcons[1].SetActive(false);
        }
        else if (lives == 2)
        {
            lifeIcons[2].SetActive(false);
        }
        else if (lives == 1)
        {
            lifeIcons[3].SetActive(false);
        }
        else if (lives == 0)
        {
            lifeIcons[4].SetActive(false);
        }
    }

    public void NextButtonCall()
    {
        nextActivated = false;
        nextButton.SetActive(false);
        omerDisappointed.SetActive(false);
        omerPleased.SetActive(false);
        if (lives == 0)
        {
            GameOver();
        }
        else
        {
            omerNeutral.SetActive(true);
            
            GetAllSentences();
        }
    }

    public void GameOver()
    {
        // deactivate and activate bois
        canvasGameplay.SetActive(false);
        map.SetActive(false);
        inputField.SetActive(true);
        gameOverScreen.SetActive(true);
        endScoreText.enabled = true;
        highScoreText.enabled = true;
        endMainMenuButton.SetActive(true);
        //Set text stuff
        endScoreText.text = "You translated " + score + " sentences!";
        highScoreText.text = highScoreList.ToString();
    }

    public void NameInputFinish()
    {
        string name = inputField.GetComponent<InputField>().text;
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
}

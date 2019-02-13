using SimpleJSON;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Translate : MonoBehaviour
{
    public float timeOutTime;
    public string timeOutMessage;

    // Should we debug?
    public bool isDebug = false;
    

    // Here's where we store the translated text!
    private string translatedText = "";

    private OmerSentences omer;

    private bool getResult = false;

    private float timer;

    private string key = "trnsl.1.1.20190130T203152Z.596852a2a42cc41e.118b50fb4d6afab313e6fa80e31283c5ddcf687a";

    // This is only called when the scene loads.
    void Start()
    {
        timer = 0;
        omer = GetComponent<OmerSentences>();
        // Strictly for debugging to test a few words!
        if (isDebug)
            StartCoroutine(Process("en", "Bonsoir."));

    }

    void Update()
    {
        if (getResult)
        {
            timer += Time.deltaTime;
            if (!translatedText.Equals("") && !translatedText.Equals(timeOutMessage))
            {
                omer.ReceiveTranslation(translatedText);
                translatedText = "";
                timer = 0;
                getResult = false;
            }
            else if(timer > timeOutTime)
            {
                omer.ReceiveTranslation(timeOutMessage);
                translatedText = "";
                timer = 0;
                getResult = false;
            }
        }
    }

    public void GetTranslation(string targetLang, string sourceText)
    {
        StartCoroutine(Process(sourceText, targetLang));

        
    }

    IEnumerator Process(string words, string language)
    {
        string strUrl = "https://translate.yandex.net/api/v1.5/tr.json/translate";
        strUrl += "?key=" + key;
        strUrl += "&text=" + UnityWebRequest.EscapeURL(words);
        strUrl += "&lang=en-" + language;
        UnityWebRequest www = UnityWebRequest.Get(strUrl);
        Debug.Log(strUrl);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Save in this here string, and then translatedText
            string translationJson = www.downloadHandler.text;
            RootObject completeTranslation = JsonUtility.FromJson<RootObject>(translationJson);
         //   Debug.Log("CompleteTranslation: " + translationJson);
           // Debug.Log("CompleteTranslation Code: " + completeTranslation.code);
            translatedText = completeTranslation.text[0];
            //Debug.Log("Final translation: " + completeTranslation.text[0]);
            getResult = true;
        }
    }

    [System.Serializable]
    public class RootObject
    {
        public int code;
        public string lang;
        public List<string> text;
    }
}

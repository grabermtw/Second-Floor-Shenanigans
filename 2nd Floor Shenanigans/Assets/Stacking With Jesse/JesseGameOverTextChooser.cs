using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JesseGameOverTextChooser : MonoBehaviour
{
    public string[] gameOverStrings;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().text = gameOverStrings[Random.Range(0, gameOverStrings.Length - 1)];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

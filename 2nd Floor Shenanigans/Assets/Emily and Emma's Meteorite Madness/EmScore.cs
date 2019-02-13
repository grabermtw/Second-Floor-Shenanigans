using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmScore : MonoBehaviour
{
    public Text scoreKeeperText;
    public string playerName;
    public EmMenuManager manager;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreKeeperText.text = playerName + ": " + score + " Meteorites";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoint()
    {
        score++;
        GetComponent<ShieldManager>().AddShieldPoint();
        scoreKeeperText.text = playerName + ": " + score + " Meteorites";
    }

    public void GameOver()
    {
        manager.EndEm(score);
        if (gameObject.name == "emily") {
            manager.EmilyKilled2P();
        }
        else
        {
            manager.EmmaKilled2P();
        }
    }
}

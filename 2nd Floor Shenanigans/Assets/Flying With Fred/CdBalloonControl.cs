using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CdBalloonControl : MonoBehaviour
{
    public Text GameScoreText;
    private static int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        transform.position = new Vector3(Random.Range(-230.0f, 230.0f), Random.Range(-128.0f, 128.0f), 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("FredParachute"))
        {
            GetComponent<AudioSource>().Play();
            score++;
            GameScoreText.text = "CDs Collected: " + score;
            Debug.Log("got balloon");
            transform.position = new Vector3(Random.Range(-230.0f, 230.0f), Random.Range(-128.0f, 128.0f), 0);
        }
    }

    public int GetScore()
    {
        return score;
    }
    public void ClearScore()
    {
        score = 0;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MobQuitter : MonoBehaviour
{
    public MobHighScores highScoreList;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            highScoreList.Save();
            Application.Quit();
        }
    }

    public void RestartScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void MainMenuReturn()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}

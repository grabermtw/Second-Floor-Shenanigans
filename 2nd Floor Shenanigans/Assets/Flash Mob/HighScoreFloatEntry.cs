using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreFloatEntry : MonoBehaviour
{
    private float score;
    private string entryName;

    public HighScoreFloatEntry(float score, string entryName)
    {
        this.score = score;
        this.entryName = entryName;
    }

    public float GetScore()
    {
        return score;
    }

    public string GetName()
    {
        return entryName;
    }

}

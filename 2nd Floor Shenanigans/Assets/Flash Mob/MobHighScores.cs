using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHighScores : MonoBehaviour
{
    ArrayList highScores = new ArrayList();

    public class GenericScoreComparer : IComparer<HighScoreFloatEntry>
    {
        //Compares the two HighScoreEntries based on score
        public int Compare(HighScoreFloatEntry x, HighScoreFloatEntry y)
        {
            if (x.GetScore() < y.GetScore())
            {
                return 1;
            }
            else if (x.GetScore() > y.GetScore())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }

    public class ScoreComparer : IComparer
    {
        // Calls GenericScoreComparer to compare the two HighScoreEntries by score
        public int Compare(object x, object y)
        {
            return (new GenericScoreComparer()).Compare((HighScoreFloatEntry)x, (HighScoreFloatEntry)y);
        }
    }

    void Start()
    {
        //PlayerPrefs.DeleteAll();
        for (int i = 0; i < 10; i++)
        {
            highScores.Add(new HighScoreFloatEntry(PlayerPrefs.GetFloat("MobFloat" + i, 100000),
                PlayerPrefs.GetString("MobString" + i)));
        }

    }

    public void AddScore(float score, string name)
    {
        int i = 0;

        //New custom comparer created to allow for sorting by score
        ScoreComparer comparer = new ScoreComparer();
        highScores.Sort(comparer);
        Debug.Log("Adding score: " + score);

        if (score < ((HighScoreFloatEntry)highScores[0]).GetScore())
        {
            Debug.Log(score + "<" + ((HighScoreFloatEntry)highScores[0]).GetScore());

            //flip this next
            //Accounts for instances of many 0's!
   //         while (score < ((HighScoreFloatEntry)highScores[i]).GetScore() &&
   //             ((HighScoreFloatEntry)highScores[i]).GetScore() == ((HighScoreFloatEntry)highScores[i + 1]).GetScore())
   //         {
   //             i++;
   //         }
            highScores.Insert(i, new HighScoreFloatEntry(score, name));
            Debug.Log("highScores at " + i + ": " + ((HighScoreFloatEntry)highScores[i]).GetScore());

            highScores.Reverse();
            // if (highScores.Count > 11)
            //{
            //  highScores.RemoveAt(0);
            //}
        }
        //highScores.Reverse();
        highScores.Reverse();
        Save();
    }

    public float GetHighScore()
    {
        return ((HighScoreFloatEntry)highScores[0]).GetScore();
    }

    public override string ToString()
    {
        //string highScoreString = "Previous Top Scores:\n";
        string highScoreString = "";
        for (int i = 0; i < 10; i++)
        {

            float sc = ((HighScoreFloatEntry)highScores[i]).GetScore();
            string minutes = ((int)sc / 60).ToString();
            string seconds = (sc % 60).ToString("f2");
            string resultingTime = minutes + ":" + seconds;

            highScoreString += (i + 1) + ") " + resultingTime + " "
                + ((HighScoreFloatEntry)highScores[i]).GetName() + "\n";
        }
        return highScoreString;
    }

    public void Save()
    {
        for (int i = 0; i < 10; i++)
        {
            PlayerPrefs.SetFloat("MobFloat" + i, ((HighScoreFloatEntry)highScores[i]).GetScore());
            PlayerPrefs.SetString("MobString" + i, ((HighScoreFloatEntry)highScores[i]).GetName());
        }
    }

    
}

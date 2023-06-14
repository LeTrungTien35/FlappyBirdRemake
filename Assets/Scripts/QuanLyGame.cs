using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuanLyGame : MonoBehaviour
{
    public static QuanLyGame ins;
    private const string HIGH_SCORE = "High Score";
    private void Awake()
    {
        MakeIns();
        IsGameStartedForTheFirstTime();
    }

    void IsGameStartedForTheFirstTime()
    {
        if(!PlayerPrefs.HasKey("IsGameStartedForTheFirstTime"))
        {
            PlayerPrefs.SetInt(HIGH_SCORE, 0);
            PlayerPrefs.SetInt("IsGameStartedForTheFirstTime", 0);
        }
    }

    void MakeIns()
    {
        if (ins != null)
        { 
            Destroy(gameObject );
        } 
        else
        {
            ins = this;
            DontDestroyOnLoad(gameObject);
        }
          
    }

    public void SetHighScore(int score)
    {
        PlayerPrefs.SetInt(HIGH_SCORE, score);
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt(HIGH_SCORE);
    }
}

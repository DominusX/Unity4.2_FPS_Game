using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class HighScore : MonoBehaviour {

    public Score score;
    public HitDamage playerDamage;

    int[] highScore;

    public int[] HighScoreList
    {
        get { return highScore; }
        set { highScore = value; }
    }

    // Use this for initialization
    void Start () {
        playerDamage.hasDied += PlayerHasDied;

        highScore = PlayerPrefsX.GetIntArray("HighScore");
	}

    private void PlayerHasDied()
    {
        List<int> newScores = new List<int>(highScore);

        newScores.Add(score.ScoreValue);

        highScore = newScores.ToArray();

        PlayerPrefsX.SetIntArray("HighScore", highScore);
    }

}

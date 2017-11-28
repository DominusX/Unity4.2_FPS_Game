using UnityEngine;
using System.Collections;
using System;

public class Score : MonoBehaviour
{
    public Spawner spawner;

    UILabel scoreLabel;

    public int ScoreValue
    {
        get { return score; }
        set { score = value; }
    }

    int score = 0;



    void Start()
    {
        scoreLabel = GetComponent<UILabel>();

        spawner.EnemyCountDecreased += EnemyCountDecreased;

        if (scoreLabel == null)
            throw new MissingComponentException("Score requires a UILabel. Not found");

        if (spawner == null)
            throw new MissingReferenceException("Must provide reference to Spawner. Not set");
    }

    private void EnemyCountDecreased(int obj)
    {
        score += 10;
        scoreLabel.text = score.ToString();
    }
}

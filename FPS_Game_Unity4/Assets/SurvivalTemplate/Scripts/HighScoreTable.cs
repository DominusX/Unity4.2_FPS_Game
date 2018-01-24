using UnityEngine;
using System.Collections;
using System.Linq;

public class HighScoreTable : MonoBehaviour {

    UILabel HighScoreTableLabel;
    HighScore mahmut;
    GameObject osman;

	void Start () {
        mahmut = GameObject.Find("Score").GetComponent<HighScore>();
        HighScoreTableLabel = GetComponent<UILabel>();


        if (mahmut == null)
            throw new MissingReferenceException("Requires a Score Gameobject with a High Score Component");

        if (HighScoreTableLabel == null)
            throw new MissingComponentException("Requires a UILabel for the score list");

        var descendingScores = mahmut.HighScoreList.OrderByDescending(d => d).ToArray();

        for ( int i = 0; i < descendingScores.Length; i++)
        {
            var rank = i + 1;
            HighScoreTableLabel.text += rank + " : " + descendingScores[i] + "\n";
        }
	}

}

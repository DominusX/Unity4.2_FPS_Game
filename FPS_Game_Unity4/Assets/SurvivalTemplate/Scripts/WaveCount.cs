using UnityEngine;
using System.Collections;

public class WaveCount : MonoBehaviour {

    public UILabel waveCountLabel;
    public UILabel EnemyCountLabel;
    Spawner spawner;

	// Use this for initialization
	void Start () {
        spawner = GetComponent<Spawner>();

        if (spawner == null)
            throw new MissingComponentException("Requires Spawner Component. Not found");

        spawner.WaveSpawned += WaveSpawned;
        spawner.EnemyCountChanged += EnemyCountDecreased;
	}
	
	void WaveSpawned(int waveCount)
    {
        waveCountLabel.text = waveCount.ToString();
    }

    private void EnemyCountDecreased(int enemyCount)
    {
        EnemyCountLabel.text = enemyCount.ToString();
    }
}

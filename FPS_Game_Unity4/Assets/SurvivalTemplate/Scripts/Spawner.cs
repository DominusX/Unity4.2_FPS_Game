using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    public float spawnOffset = 3.0f;
    public float SpawnDelay = 5;

    int currentEnemyCount;
    int currentWaveNumber = 1;

    Vector3 randomSpawnPoint //reference to a random spawn point
    {
        get
        {
            //this means it accessing childcount from parent gameobject
            //which means everytime it randomly spawns from 2 place (3-1)
            int randIndex = Random.Range(0, transform.childCount - 1);

            //for offsetting spiders to not to spawn on top of each other
            var position = transform.GetChild(randIndex).position + Random.insideUnitSphere * spawnOffset;
            position.y = 0.1f;
            return position;
        }
    }

    void Update()
    {
        CheckIfReadySpawn();

    }

    private void CheckIfReadySpawn()
    {
        if (currentWaveNumber <= 0)
        {
            currentEnemyCount++;
            currentEnemyCount = currentWaveNumber * 5; //each wave will increase by five enemies
            Invoke("Spawn", SpawnDelay);
        }
            
    }

    void Start()
    {
        currentEnemyCount = currentWaveNumber * 5; //each wave will increase by five enemies
        
        Spawn();
    }

    private void Spawn()
    {
        Debug.Log("wave starting: " + currentWaveNumber);
        for (int i = 0; i < currentEnemyCount; i++) //looping through count of spawn points
        {
            var enemyGameObject = (GameObject)Instantiate(enemy, randomSpawnPoint, Quaternion.identity);

            var hitDamage = enemyGameObject.GetComponent<HitDamage>();//reference for HitDamage script on enemy(spider) game object

            hitDamage.hasDied = EnemyHasDied;

            SetAITarget(enemyGameObject);
        }
    }

    void EnemyHasDied()
    {
        Debug.Log("died");
        currentEnemyCount--;
    }

    private void SetAITarget(GameObject enemyGameObject)
    {
        var ai = enemyGameObject.GetComponent<AIFollow>();
        ai.target = player.transform;
    }
}

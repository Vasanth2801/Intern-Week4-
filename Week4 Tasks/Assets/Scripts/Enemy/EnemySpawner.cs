using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    [System.Serializable]
    public class Wave
    {
        public Enemy[] enemies;
        public int timeBetweenEnemies;
        public int timeBetweenWaves;
        public int enemyCount;
    }

    public Wave[] waves;
    public Transform[] spawnPoint;
    public int currentWave;
    public float countDown;
    bool countDownToBegin = false;

    private void Start()
    {
        countDownToBegin = true;
        for(int i = 0; i < waves.Length; i++)
        {
            waves[i].enemyCount = waves[i].enemies.Length;
        }
    }

    private void Update()
    {
        if(currentWave >= waves.Length)
        {
            Debug.Log("All Waves Completed!");
            return;
        }

        if(countDownToBegin == true)
        {
            countDown -= Time.deltaTime;
        }

        if(countDown <= 0)
        {
            countDownToBegin = false;
            countDown = waves[currentWave].timeBetweenWaves;
            StartCoroutine(SpawnWave());
        }

        if(waves[currentWave].enemyCount == 0)
        {
            currentWave++;
            countDownToBegin = true;
        }
    }

    IEnumerator SpawnWave()
    {
        if(currentWave < waves.Length)
        {
            for (int i = 0; i < waves[currentWave].enemies.Length; i++)
            {
                Transform spawnPoints = spawnPoint[Random.Range(0, spawnPoint.Length)];
                Enemy enemy = Instantiate(waves[currentWave].enemies[i], spawnPoints.position, spawnPoints.rotation);
                yield return new WaitForSeconds(waves[currentWave].timeBetweenEnemies);
            }
        }

    }

}

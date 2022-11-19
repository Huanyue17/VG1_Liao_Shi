using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class GameController : MonoBehaviour
    {
        public static GameController instance;

        // outlets
        public Transform[] SpawnAnimalsPoints;
        // Enemy Flowers
        public Transform[] spawnEFPoints;
        // Reward Flowers
        public Transform[] spawnRFPoints;
        // Rewars: bullet, medicine
        public Transform[] spawnRewardPoints;
        public GameObject[] animalsPrefabs;
        public GameObject[] efPrefabs;
        public GameObject[] rfPrefabs;
        public GameObject[] rewardPrefabs;

        //configuration
        public float maxEnemiesDelay = 10f;
        public float minEnemiesDelay = 2f;
        public float maxRewardDelay = 8f;
        public float minRewardDelay = 3f;
        public int maxAnimalsNum = 3;
        public int maxEFNum = 5;
        public int maxRFNum = 5;
        public int maxRewardsNum = 1;

        // state tracking
        public float timeElapsed;
        public float enemiesDelay;
        public float rewardDelay;
        public int animalsNum;
        public int efNum;
        public int rfNum;
        public int rewardsNum;

        // methos
        void Awake()
        {
            instance = this;
        }

        void Start() {
            StartCoroutine("SpawnAnimalsTimer");
        }

        void Update()
        {
            // increment passage of time for each frame of the game
            timeElapsed += Time.deltaTime;

            //computrt delay
            float decreaseDelayOverTime = maxEnemiesDelay - ((maxEnemiesDelay - minEnemiesDelay) / 30f * timeElapsed);
            enemiesDelay = Mathf.Clamp(decreaseDelayOverTime, minEnemiesDelay, maxEnemiesDelay);
        }

        void SpawnAnimals() {
            //pick random spawn points and random aniaml prefabs
            int randomSpawnIndex = Random.Range(0, SpawnAnimalsPoints.Length);
            Transform randomSpawnPoint = SpawnAnimalsPoints[randomSpawnIndex];
            int randomEnemiesIndex = Random.Range(0, animalsPrefabs.Length);
            GameObject randomEnemiesPrefab = animalsPrefabs[randomEnemiesIndex];


            //spawn
            Instantiate(randomEnemiesPrefab, randomSpawnPoint.position, Quaternion.identity);
            animalsNum++;
        }

         void SpawnEF() {
            //pick random spawn points and random enemy flower prefabs
            int randomSpawnIndex = Random.Range(0, spawnEFPoints.Length);
            Transform randomSpawnPoint = spawnEFPoints[randomSpawnIndex];
            int randomEnemiesIndex = Random.Range(0, efPrefabs.Length);
            GameObject randomEnemiesPrefab = efPrefabs[randomEnemiesIndex];


            //spawn
            Instantiate(randomEnemiesPrefab, randomSpawnPoint.position, Quaternion.identity);
            efNum++;
        }

        void SpawnRF() {
            //pick random spawn points and random reward flower prefabs
            int randomSpawnIndex = Random.Range(0, spawnRFPoints.Length);
            Transform randomSpawnPoint = spawnRFPoints[randomSpawnIndex];
            int randomEnemiesIndex = Random.Range(0, rfPrefabs.Length);
            GameObject randomRFPrefab = rfPrefabs[randomEnemiesIndex];


            //spawn
            Instantiate(randomRFPrefab, randomSpawnPoint.position, Quaternion.identity);
            rfNum++;
        }

        void SpawnRewards() {
            //pick random spawn points and random reward flower prefabs
            int randomSpawnIndex = Random.Range(0, spawnRewardPoints.Length);
            Transform randomSpawnPoint = spawnRewardPoints[randomSpawnIndex];
            int randomRewardIndex = Random.Range(0, rewardPrefabs.Length);
            GameObject randomRewardsPrefab = rewardPrefabs[randomRewardIndex];


            //spawn
            Instantiate(randomRewardsPrefab, randomSpawnPoint.position, Quaternion.identity);
            rewardsNum++;
        }


        IEnumerator SpawnAnimalsTimer() {
            //wait
            yield return new WaitForSeconds(enemiesDelay);

            //spawn
            if (animalsNum < maxAnimalsNum) {
                SpawnAnimals();
                //repeat
                StartCoroutine("SpawnAnimalsTimer");
            }
        }
    }
}
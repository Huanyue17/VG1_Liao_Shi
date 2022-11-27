using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class GameController : MonoBehaviour {
        public static GameController instance;

        // outlets
        public Transform[] SpawnAnimalsPoints;
        // Enemy Flowers
        public Transform[] spawnEFPoints;
        public bool[] EFOccupied;
        // Reward Flowers
        public Transform[] spawnRFPoints;
        public bool[] RFOccupied;
        // Rewars: bullet, medicine
        public Transform[] spawnRewardPoints;
        public bool[] RwdOccupied;
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
        void Awake() {
            instance = this;
        }

        void Start() {
            EFOccupied = new bool[spawnEFPoints.Length];
            RFOccupied = new bool[spawnRFPoints.Length];
            RwdOccupied = new bool[spawnRewardPoints.Length];
            StartCoroutine("SpawnAnimalsTimer");
            StartCoroutine("SpawnRewardsTimer");
            StartCoroutine("SpawnEFTimer");
            StartCoroutine("SpawnRFTimer");
            animalsNum = 0;
            rewardsNum = 0;
            efNum = 0;
            rfNum = 0;
        }

        void Update() {
            // increment passage of time for each frame of the game
            timeElapsed = (animalsNum + rewardsNum + efNum + rfNum + 1) * 3f;
            float totalMax = maxEFNum + maxAnimalsNum + maxRFNum + maxRewardsNum;

            //computrt delay
            float decreaseDelayOverTime = maxEnemiesDelay - ((maxEnemiesDelay - minEnemiesDelay) / totalMax * timeElapsed);
            float decreaseDelayOverTime2 = maxRewardDelay - ((maxRewardDelay - minRewardDelay) / totalMax * timeElapsed);
            enemiesDelay = Mathf.Clamp(decreaseDelayOverTime, minEnemiesDelay, maxEnemiesDelay);
            rewardDelay = Mathf.Clamp(decreaseDelayOverTime2, minRewardDelay, maxRewardDelay);
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
            if (!EFOccupied[randomSpawnIndex]) {
                Transform randomSpawnPoint = spawnEFPoints[randomSpawnIndex];
                int randomEnemiesIndex = Random.Range(0, efPrefabs.Length);
                GameObject randomEnemiesPrefab = efPrefabs[randomEnemiesIndex];

                //spawn
                GameObject newEF = Instantiate(randomEnemiesPrefab, randomSpawnPoint.position, Quaternion.identity);
                // Debug.Log("Enamy flower idx: " + randomSpawnIndex + "occupied?" + EFOccupied[randomSpawnIndex]);
                newEF.tag = "EF"+randomSpawnIndex.ToString();
                EFOccupied[randomSpawnIndex] = true;
                efNum++;
            }
        }

        void SpawnRF() {
            //pick random spawn points and random reward flower prefabs
            int randomSpawnIndex = Random.Range(0, spawnRFPoints.Length);
            if (!RFOccupied[randomSpawnIndex]) {
                Transform randomSpawnPoint = spawnRFPoints[randomSpawnIndex];
                int randomEnemiesIndex = Random.Range(0, rfPrefabs.Length);
                GameObject randomRFPrefab = rfPrefabs[randomEnemiesIndex];

                //spawn
                GameObject newRF = Instantiate(randomRFPrefab, randomSpawnPoint.position, Quaternion.identity);
                newRF.tag = "RF"+randomSpawnIndex.ToString();
                RFOccupied[randomSpawnIndex] = true;
                rfNum++;
            }
        }

        void SpawnRewards() {
            //pick random spawn points and random reward flower prefabs
            int randomSpawnIndex = Random.Range(0, spawnRewardPoints.Length);
            if (!RwdOccupied[randomSpawnIndex]) {
                Transform randomSpawnPoint = spawnRewardPoints[randomSpawnIndex];
                int randomRewardIndex = Random.Range(0, rewardPrefabs.Length);
                GameObject randomRewardsPrefab = rewardPrefabs[randomRewardIndex];

                //spawn
                GameObject newRwd = Instantiate(randomRewardsPrefab, randomSpawnPoint.position, Quaternion.identity);
                newRwd.tag = "RWD"+randomSpawnIndex.ToString();
                RwdOccupied[randomSpawnIndex] = true;
                rewardsNum++;
            }
        }


        IEnumerator SpawnAnimalsTimer() {
                //wait
            yield return new WaitForSeconds(enemiesDelay);
            //spawn
            if (animalsNum < maxAnimalsNum) {
                SpawnAnimals();
            }
            //repeat
            StartCoroutine("SpawnAnimalsTimer");
        }

        IEnumerator SpawnRewardsTimer() {
            yield return new WaitForSeconds(rewardDelay);
            //spawn
            if (rewardsNum < maxRewardsNum) {
                SpawnRewards();
            }
            //repeat
            StartCoroutine("SpawnRewardsTimer");
        }

        IEnumerator SpawnEFTimer() {
            yield return new WaitForSeconds(enemiesDelay);
            //spawn
            if (efNum < maxEFNum) {
                SpawnEF();
            }
            //repeat
            StartCoroutine("SpawnEFTimer");
        }

        IEnumerator SpawnRFTimer() {
            yield return new WaitForSeconds(rewardDelay);
            //spawn
            if (rfNum < maxRFNum) {
                SpawnRF();
            }
            //repeat
            StartCoroutine("SpawnRFTimer");
        }

    }
}
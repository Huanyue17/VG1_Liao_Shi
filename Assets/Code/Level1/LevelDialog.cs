using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

namespace level1 {
    public class LevelDialog : MonoBehaviour {
        public static LevelDialog instance;
        public TMP_Text titleContent;
        public TMP_Text finalTime;
        public GameObject[] seeds;
        private int seedsCount;
        private int curHealth;


        void Awake() {
            instance = this;
            Hide();
        }

        void Start() {
            int curHealth = PlayerMovement.shennong.health;
        }

        // Update is called once per frame
        void Update() {
            finalTime.text = GameScore.instance.GetTimeStr(Time.timeSinceLevelLoad);
        }

        public void seedsAcheived(bool flag) {
            float usedTime = Time.timeSinceLevelLoad;
            for (int i = 0; i < 3; i++) {
                seeds[i].SetActive(false);
            }
            if (usedTime < 200) {
                seeds[0].SetActive(flag);
            }
            if (usedTime < 150) {
                seeds[1].SetActive(flag);
            }
            if (   usedTime < 100) {
                seeds[2].SetActive(flag);
            }
        }

        public void Success() {
            titleContent.text = "Success";
            this.Show();
            seedsAcheived(true);
        }

        public void Fail() {
            titleContent.text = "Fail";
            this.Show();
            seedsAcheived(false);
        }

        public void Show() {
            gameObject.SetActive(true);
        }
        public void Hide() {
            gameObject.SetActive(false);
        }

        public void Restart() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Time.timeScale = 1;
        }

        public void BackToMain() {
            SceneManager.LoadScene("MainMenu");
        }
    }
}

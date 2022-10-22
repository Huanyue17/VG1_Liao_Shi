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

        void Awake() {
            instance = this;
            Hide();
        }

        void Start() {
        }

        // Update is called once per frame
        void Update() {
            finalTime.text = GameScore.instance.GetTimeStr(Time.timeSinceLevelLoad);
        }
 
        public int seedsCalculate() {
            float usedTime = Time.timeSinceLevelLoad;
            int count = 0;
            if (usedTime < 200) count++;
            if (usedTime < 150) count++;
            if (usedTime < 90) count++;
            return count;
        }

        public void Success() {
            titleContent.text = "Success";
            this.Show();
        }

        public void Fail() {
            titleContent.text = "Fail";
            this.Show();
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
    }
}

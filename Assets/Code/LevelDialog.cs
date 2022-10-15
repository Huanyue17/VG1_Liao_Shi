using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace level1 {
    public class LevelDialog : MonoBehaviour {
        public static LevelDialog instance;
        public TMP_Text titleContent;
        public TMP_Text finalTime;

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

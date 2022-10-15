using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace level1 {
    [System.Serializable]
    public class GameScore : MonoBehaviour {
        public static GameScore instance;
        // Outlet
        Rigidbody2D _rigidbody;
        public TMP_Text textScore;
        public TMP_Text clockerText;
        //public int goalScore;

        // Tracking state
        public int score;

        void Awake() {
            instance = this;
        }

        void Start() {
            score = 0;
            //score = PlayerPrefs.GetInt("Score");
        }

        // Update is called once per frame
        void Update() {
            UpdateDisplay();
        }

        public string GetTimeStr(float inputTime) {
            int mm = (int)(inputTime / 60f);
            int ss = (int)(inputTime % 60f);
            return mm.ToString("00") + ":" + ss.ToString("00");
        }

        void UpdateDisplay() {
            clockerText.text = GetTimeStr(Time.timeSinceLevelLoad);
            textScore.text = score.ToString();
        }

        public void EarnPoints(int pointAmount) {
            score += pointAmount;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace level1 {
    [System.Serializable]
    public class GameScore : MonoBehaviour
    {
        public static GameScore instance;
        // Outlet
        Rigidbody2D _rigidbody;
        public TMP_Text textScore;
        public TMP_Text clockerText;
        //public int goalScore;

        // Tracking state
        public int score;
        public float seconds, minutes;

        void Awake(){
            instance = this;
        }
        void Start()
        {
            score = 0;
            seconds = 0f;
            minutes = 0f;
            
            score = PlayerPrefs.GetInt("Score");
        }

        // Update is called once per frame
        void Update()
        {
            minutes = (int)(Time.time/60f);
            seconds = (int)(Time.time%60f);
            clockerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
            UpdateDisplay();
        }

        void UpdateDisplay() {
            textScore.text = score.ToString();
        }

        public void EarnPoints(int pointAmount) {
            score += pointAmount;
        }
    }
}


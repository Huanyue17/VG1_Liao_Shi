using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace level1 {
    public class GameScore : MonoBehaviour
    {
        public static GameScore instance;
        // Outlet
        Rigidbody2D _rigidbody;
        public TMP_Text textScore;

        // Tracking state
        public int score;


        void Start()
        {
            score = 0;
        }

        // Update is called once per frame
        void Update()
        {
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


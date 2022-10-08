using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


namespace level1 {
    public class LevelDialog : MonoBehaviour {
        public static LevelDialog instance;
        public TMP_Text titleContent;


        void Awake() {
            instance = this;
            Hide();
        }

        void Start() {


        }

        // Update is called once per frame
        void Update() {

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

    }
}

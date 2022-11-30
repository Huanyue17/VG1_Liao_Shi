using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace level1 {
    public class PauseMenu : MonoBehaviour
    {
        public static PauseMenu instance;
        // Outlet

        void Awake() {
            instance = this;
            gameObject.SetActive(false);
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void Continuous() {
            gameObject.SetActive(false);
            Time.timeScale = 1;
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

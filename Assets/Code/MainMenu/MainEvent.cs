using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace level1 {
    public class MainEvent : MonoBehaviour {
        public static MainEvent instance;
        // Outlet
        public GameObject mainMenu;
        public GameObject playMenu;
        public GameObject setMenu;
        public GameObject tutorMenu;
        public GameObject audioMenu;

        void Awake() {
            instance = this;
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        void SwitchMenu(GameObject someMenu) {
            // clean-up Menus
            mainMenu.SetActive(false);
            setMenu.SetActive(false);
            tutorMenu.SetActive(false);
            audioMenu.SetActive(false);
            playMenu.SetActive(false);
            // turn on requested menu
            someMenu.SetActive(true);
        }

        public void ShowMainMenu() {
            SwitchMenu(mainMenu);
        }

        public void ShowPlayMenu() {
            SwitchMenu(playMenu);
        }

        public void ShowSetMenu() {
            SwitchMenu(setMenu);
        }

        public void ShowTutorMenu() {
            SwitchMenu(tutorMenu);
        }

        public void ShowAudioMenu() {
            SwitchMenu(audioMenu);
        }

        public void LoadLevel1() {
            SceneManager.LoadScene("Level1");
            Time.timeScale = 1;
        }

        public void LoadLevel2() {
            SceneManager.LoadScene("Infinity");
            Time.timeScale = 1;
        }
    }
}
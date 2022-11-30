using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class SoundManager : MonoBehaviour {
        public static SoundManager instance;

        // Outlets
        public string area;
        AudioSource audiosource;
        public AudioClip BGMVillage;
        public AudioClip BGMDesert;
        public AudioClip scoreSound;
        public AudioClip gameOverSound;
        public AudioClip hitByVineSound;
        public AudioClip killSound;
        public AudioClip shootSound;
        public AudioClip powerUpSound;
        public AudioClip successSound;

        void Awake() {
            instance = this;
        }

        void Start() {
            audiosource = GetComponent<AudioSource>();
            audiosource.clip = BGMVillage;
            StartBGM();
        }

        void Update() {
            SwitchBGM();
            AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        void SwitchBGM() {
            if (area == "desert") {
                if (audiosource.clip != BGMDesert) {
                    audiosource.clip = BGMDesert;
                    StartBGM();
                }
            } else {
                if (audiosource.clip != BGMVillage) {
                    audiosource.clip = BGMVillage;
                    StartBGM();
                }
            }
        }

        public void StartBGM() {
            // audiosource.enabled = true;
            audiosource.Play();
        }

        public void StopBGM() {
            audiosource.Stop();
            // audiosource.enabled = false;
        }

        public void PlaySoundScore() {
            audiosource.PlayOneShot(scoreSound);
        }

        public void PlaySoundGameOver() {
            audiosource.PlayOneShot(gameOverSound);
        }

        public void PlaySoundHitByVine() {
            audiosource.PlayOneShot(hitByVineSound);
        }

        public void PlaySoundKill() {
            audiosource.PlayOneShot(killSound);
        }

        public void PlaySoundShoot() {
            audiosource.PlayOneShot(shootSound);
        }

        public void PlaySoundPowerUp() {
            audiosource.PlayOneShot(powerUpSound);
        }
        public void PlaySoundSuccess() {
            audiosource.PlayOneShot(successSound);
        }
    }
}
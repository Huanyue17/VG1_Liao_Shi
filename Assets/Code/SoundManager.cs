using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class SoundManager : MonoBehaviour {
        public static SoundManager instance;

        // Outlets
        AudioSource audiosource;
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
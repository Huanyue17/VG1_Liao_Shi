using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class ReachGoal : MonoBehaviour {
        public static ReachGoal instance;
        BoxCollider2D _bc;
        public int goalScore = 10;

        void Start() {
            instance = this;
        }

        void OnTriggerEnter2D(Collider2D other) {
            if (other.gameObject.GetComponent<PlayerMovement>()
                && GameScore.instance.score >= goalScore) {
                print("Success!");
                SoundManager.instance.PlaySoundSuccess();
                //_rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                Time.timeScale = 0;
                LevelDialog.instance.Success();
            }
        }
    }
}


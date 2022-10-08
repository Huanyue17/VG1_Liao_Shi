using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class ObstacleFlower : MonoBehaviour {
        // Outlets
        PolygonCollider2D _pc;
        Animator _animator;
        //public PlayerMovement shennong;
        //private GameObject Target;
        public float warningDistance = 0.1f;

        private void Start() {
            _pc = GetComponent<PolygonCollider2D>();
            _animator = GetComponent<Animator>();
            //PlayerMovement.shennong = FindObjectOfType<PlayerMovement>();
        }

        // Update is called once per frame
        void Update() {
            // if((shennong.transform.position - this.transform.position).sqrMagnitude < warningDistance) {
            //     //GameScore.instance.EarnPoints(5);
            // }
        }

        // when attacked by player
        public void Break() {
            Destroy(gameObject);
        }

    }
}



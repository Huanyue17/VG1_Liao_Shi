using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class RewardBullet : MonoBehaviour {
        PolygonCollider2D _pc;
        public int rewardS = 10;

        void Start() {
            _pc = GetComponent<PolygonCollider2D>();
        }

        public void Break() {
            Destroy(gameObject);
        }

    }
}


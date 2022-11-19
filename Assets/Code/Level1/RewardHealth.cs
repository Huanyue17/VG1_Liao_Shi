using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class RewardHealth : MonoBehaviour {
        PolygonCollider2D _pc;

        void Start() {
            _pc = GetComponent<PolygonCollider2D>();
        }

        public void Break() {
            Destroy(gameObject);
        }

    }
}
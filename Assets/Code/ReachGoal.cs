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

    }
}


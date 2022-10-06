using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class obstacleFlower : MonoBehaviour
    {
        // Outlets
        PolygonCollider2D _pc;
        Animator _animator;
        public PlayerMovement shennong;
        //private GameObject Target;
        
        private void Start()
        {
            _pc = GetComponent<PolygonCollider2D>();
            _animator = GetComponent<Animator>();
            shennong = FindObjectOfType<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        // when attacked by player
        public void Break() {
            Destroy(gameObject);
        }

    }
}



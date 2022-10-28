using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class Projectile : MonoBehaviour
    {
        // outlets
        Rigidbody2D _rb;
        public GameObject explosionPrefab;
        public float acceleration;
        public float maxTime;
        Vector2 oriLoc;
        float createT;
        PlayerMovement shennong;
        Direction facing;

        void Start() {
            _rb = GetComponent<Rigidbody2D>();
            createT = Time.time;
            shennong = PlayerMovement.shennong;
        }

        // Update is called once per frame
        void Update() {
            for (int i = 0; i < shennong.sprites.Length; i++) {
                if (shennong._spriteRenderer.sprite == shennong.sprites[i]) {
                    facing = (Direction)i;
                    break;
                }
            }

            //Direction facing = PlayerMovement.shennong.facingDirection;
            Debug.Log(facing);
            Vector2[] directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};

            if (Time.time - createT < maxTime) {
                _rb.AddForce(Vector2.right * acceleration);
            } else {
                Destroy(gameObject);
            }
        }

        void OnCollisionEnter2D(Collision2D other) {
            Destroy(gameObject);
            // Only explode on Asteroids
            if (other.gameObject.GetComponent<LizardControl>()
                || other.gameObject.GetComponent<ObstacleFlower>()) {
                Destroy(other.gameObject);

                // Create an explosion and destroy it soon after
                GameObject explosion = Instantiate(
                    explosionPrefab,
                    transform.position,
                    Quaternion.identity
                );
                Destroy(explosion, 0.25f);
            }
        }
    }

}

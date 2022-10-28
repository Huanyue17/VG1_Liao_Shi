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
        //SpriteRenderer sprite;
        
        // tracking
        Vector2 oriLoc;
        float createT;
        Direction facing;

        void Start() {
            _rb = GetComponent<Rigidbody2D>();
            //sprite = GetComponent<SpriteRenderer>();
            createT = Time.time;
            facing = FindObjectOfType<PlayerMovement>().facingDirection;
            Vector3[] angles = {new Vector3(0, 0, 90), new Vector3(0, 0, 270), new Vector3(0, 180, 0), new Vector3(0, 0, 0)};
            RotateProjectile((int)facing, angles);
        }

        // Update is called once per frame
        void Update() {
            //facing = FindObjectOfType<PlayerMovement>().facingDirection;
            //facing = PlayerMovement.shennong.facingDirection;
            //Direction facing = PlayerMovement.shennong.facingDirection;
            //Debug.Log((int)facing);
            Vector2[] directions = {Vector2.up, Vector2.down, Vector2.left, Vector2.right};
            // Vector3[] angles = {new Vector3(0, 270, 0), new Vector3(0, 90, 0), new Vector3(0, 180, 0), new Vector3(0, 0, 0)};
            // RotateProjectile((int)facing, angles);
            if (Time.time - createT < maxTime) {
                _rb.AddForce(directions[(int)facing] * acceleration);
                
            } else {
                Destroy(gameObject);
            }
        }

        void RotateProjectile(int dir, Vector3[] angles) {
            Vector3 rotationToAdd = angles[dir];
            transform.Rotate(rotationToAdd);
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

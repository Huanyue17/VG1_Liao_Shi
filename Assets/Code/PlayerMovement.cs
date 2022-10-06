using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace level1 {
    public class PlayerMovement : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody;
        Animator _animator;

        // Configuration
        public KeyCode keyUp;
        public KeyCode keyDown;
        public KeyCode keyLeft;
        public KeyCode keyRight;
        public KeyCode keyAttack;
        public float moveSpeed;


        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void FixedUpdate() {
            // Move PLayer Left
            if (Input.GetKey(keyLeft)) {
                _rigidbody.AddForce(Vector2.left * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }

            // Move PLayer Right
            if (Input.GetKey(keyRight)) {
                _rigidbody.AddForce(Vector2.right * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            }

            // Move PLayer Upward
            if (Input.GetKey(keyUp)) {
                _rigidbody.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            }

            // Move PLayer Down
            if (Input.GetKey(keyDown)) {
                _rigidbody.AddForce(Vector2.down * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }

        void Update() {
            float movementSpeed = _rigidbody.velocity.sqrMagnitude;
            _animator.SetFloat("speed", movementSpeed);
            if (movementSpeed > 0.1f) {
                _animator.SetFloat("movementX", _rigidbody.velocity.x);
                _animator.SetFloat("movementY", _rigidbody.velocity.y);
            }

            if(Input.GetKeyDown(keyAttack)) {
                _animator.SetTrigger("attack");
            }
        }
    }
}

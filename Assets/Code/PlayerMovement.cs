using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace level1 {
    public class PlayerMovement : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody2D;

        // Configuration
        public KeyCode keyUp;
        public KeyCode keyDown;
        public KeyCode KeyLeft;
        public KeyCode KeyRight;
        public float moveSpeed;


        void Start() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void fixedUpdate() {
            // Move PLayer Left
            if (Input.GetKey(KeyLeft)) {
                _rigidbody2D.AddForce(Vector2.left * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }

            // Move PLayer Right
            if (Input.GetKey(KeyRight)) {
                _rigidbody2D.AddForce(Vector2.right * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            }

            // Move PLayer Upward
            if (Input.GetKey(keyUp)) {
                _rigidbody2D.AddForce(Vector2.up * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);

            }

            // Move PLayer Down
            if (Input.GetKey(keyDown)) {
                _rigidbody2D.AddForce(Vector2.down * moveSpeed * Time.fixedDeltaTime, ForceMode2D.Impulse);
            }
        }
    }
}

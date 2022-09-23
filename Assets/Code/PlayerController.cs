using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace level1 {
    public class PlayerController : MonoBehaviour
    {
        // Outlet
        Rigidbody2D _rigidbody2D;

        void Start()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }


        void Update()
        {
            // Move PLayer Left
            if (Input.GetKey(KeyCode.A)) {
                _rigidbody2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);
            }

            // Move PLayer Right
            if (Input.GetKey(KeyCode.D)) {
                _rigidbody2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);
            }

            // Move PLayer Upward
            if (Input.GetKey(KeyCode.W)) {
                _rigidbody2D.AddForce(Vector2.up * 18f * Time.deltaTime, ForceMode2D.Impulse);
            }

            // Move PLayer Down
            if (Input.GetKey(KeyCode.S)) {
                _rigidbody2D.AddForce(Vector2.down * 18f * Time.deltaTime, ForceMode2D.Impulse);
            }
        }
    }
}


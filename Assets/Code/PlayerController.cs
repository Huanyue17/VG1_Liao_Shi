using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class PlayerController : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody2D;
        private bool isMoving;
        private Vector2 origPos, targetPos;
        private float unitMoveTime = 0.5f;
        Animator animator;

        void Start() {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            isMoving = false;
        }

        // void FixedUpdate() {
        //     // This Update Event is syna'd with the Physics Engine
        //     animator.SetFloat("Speed", _rigidbody2D.velocity.magnitude);
        //     if (_rigidbody2D.velocity.magnitude > 0) {
        //         animator.speed = _rigidbody2D.velocity.magnitude / 3f;
        //     } else {
        //         animator.speed = 1f;
        //     }
        // }

        void Update() {
            // Move PLayer Upward
            if (Input.GetKey(KeyCode.W) && !isMoving) {
                _rigidbody2D.AddForce(Vector2.up * 18f * Time.deltaTime, ForceMode2D.Impulse);
                // StartCoroutine(MovePlayer(Vector2.up));
                animator.SetInteger("Direction", 0);
            }

            // Move PLayer Right
            if (Input.GetKey(KeyCode.D) && !isMoving) {
                _rigidbody2D.AddForce(Vector2.right * 18f * Time.deltaTime, ForceMode2D.Impulse);
                // StartCoroutine(MovePlayer(Vector2.right));
                animator.SetInteger("Direction", 1);
            }

            // Move PLayer Down
            if (Input.GetKey(KeyCode.S) && !isMoving) {
                _rigidbody2D.AddForce(Vector2.down * 18f * Time.deltaTime, ForceMode2D.Impulse);
                // StartCoroutine(MovePlayer(Vector2.down));
                animator.SetInteger("Direction", 2);
            }

            // Move PLayer Left
            if (Input.GetKey(KeyCode.A) && !isMoving) {
                _rigidbody2D.AddForce(Vector2.left * 18f * Time.deltaTime, ForceMode2D.Impulse);
                // StartCoroutine(MovePlayer(Vector2.left));
                animator.SetInteger("Direction", 3);
            }
        }

        // private IEnumerator MovePlayer(Vector2 direction) {
        //     isMoving = true;
        //     float elapseTime = 0f;

        //     origPos = transform.position;
        //     targetPos = origPos + direction;

        //     while (elapseTime < unitMoveTime) {
        //         transform.position = Vector2.Lerp(origPos, targetPos, (elapseTime / unitMoveTime));
        //         elapseTime += Time.deltaTime;
        //         yield return null;
        //     }

        //     isMoving = false;
        //     //transform.Translate(direction*speed*Time.deltaTime);
        //     transform.position = targetPos;
        // }
    }
}


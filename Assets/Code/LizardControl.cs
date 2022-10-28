using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace level1 {
    public class LizardControl : MonoBehaviour {
        Transform target;

        Rigidbody2D _rb;
        Animator _animator;
        Vector2 directionToTarget;

        public float acceleration;
        public float maxSpeed;
        public float chaseDistance;

        // Start is called before the first frame update
        void Start() {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update() {
            // Home in on target
            ChooseNearestTarget();
            if (target != null) {
                // Rotate towards target
                directionToTarget = target.position - transform.position;
                float angle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
                _rb.AddForce(directionToTarget * acceleration);
                _rb.velocity = Vector2.ClampMagnitude(_rb.velocity, maxSpeed);
            }
            ChangeAnimationDirection();
        }

        void ChooseNearestTarget() {
            // Expensive function. Correct approach would be object pooling.
            PlayerMovement player = FindObjectOfType<PlayerMovement>();

            Vector2 directionToTarget = player.transform.position - transform.position;

            // Filter for the closest target we've seen so far
            if (directionToTarget.sqrMagnitude < chaseDistance) {
                target = player.transform;
            } else {
                target = null;
                // _rb.velocity = Vector2.zero;
            }

        }

        void ChangeAnimationDirection() {
            float moveSpeed = _rb.velocity.sqrMagnitude;
            if (moveSpeed > 0.01f) {
                _animator.SetBool("move", true);
                if (Mathf.Abs(_rb.velocity.x) > Mathf.Abs(_rb.velocity.y)) {
                    _animator.SetFloat("directionX", _rb.velocity.x/Mathf.Abs(_rb.velocity.x));
                    _animator.SetFloat("directionY", 0f);
                } else {
                    _animator.SetFloat("directionX", 0f);
                    _animator.SetFloat("directionY", _rb.velocity.y/Mathf.Abs(_rb.velocity.y));
                }
            } else {
                _animator.SetBool("move", false);
                _animator.SetFloat("directionX", 0f);
                _animator.SetFloat("directionY", 0f);
            }
        }

    }
}

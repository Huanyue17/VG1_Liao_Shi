using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace level1 {
    public enum Direction {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    public class PlayerMovement : MonoBehaviour {
        // Outlet
        Rigidbody2D _rigidbody;
        Animator _animator;
        SpriteRenderer _spriteRenderer;
        public Transform[] attackZones;

        // Configuration
        public KeyCode keyUp;
        public KeyCode keyDown;
        public KeyCode keyLeft;
        public KeyCode keyRight;
        public KeyCode keyAttack;
        public float moveSpeed;
        public Sprite[] sprites;

        // Tracking state
        public Direction facingDirection;


        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
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

            // convert the enumeration to an index
            int facingDirectionIndex = (int)facingDirection;
            Transform attackZone = attackZones[facingDirectionIndex];
            Collider2D[] hits = Physics2D.OverlapCircleAll(attackZone.position, 0.1f);

            foreach(Collider2D hit in hits) {
                obstacleFlower obs = hit.GetComponent<obstacleFlower>();
                if(obs) {
                    if(Input.GetKeyDown(keyAttack)) {
                        obs.Break();
                    }
                }
            }
        }

        void LateUpdate() {
            for(int i = 0; i < sprites.Length; i++) {
                if(_spriteRenderer.sprite == sprites[i]) {
                    facingDirection = (Direction)i;
                    break;
                }
            }
        }
    }
}

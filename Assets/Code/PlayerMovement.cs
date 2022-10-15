using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace level1 {
    public enum Direction {
        Up = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    public class PlayerMovement : MonoBehaviour {
        public static PlayerMovement shennong;
        // Outlet
        Rigidbody2D _rigidbody;
        Animator _animator;
        SpriteRenderer _spriteRenderer;
        public Transform[] attackZones;
        HealthHeart heart;
        LevelDialog _levelDialog;
        //public TMP_Text textScore;
        // public Image imageHealth;

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
        public int healthMax = 4;
        public int health = 4;

        void Awake() {
            shennong = this;
        }

        void Start() {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
            heart = FindObjectOfType<HealthHeart>();
            _levelDialog = LevelDialog.instance;

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
            if (health > 0) {
                float movementSpeed = _rigidbody.velocity.sqrMagnitude;
                _animator.SetFloat("speed", movementSpeed);
                if (movementSpeed > 0.1f) {
                    _animator.SetFloat("movementX", _rigidbody.velocity.x);
                    _animator.SetFloat("movementY", _rigidbody.velocity.y);
                }

                if (Input.GetKeyDown(keyAttack)) {
                    _animator.SetTrigger("attack");
                    // TakeDamage(1);
                }

                // convert the enumeration to an index
                int facingDirectionIndex = (int)facingDirection;
                Transform attackZone = attackZones[facingDirectionIndex];
                Collider2D[] hits = Physics2D.OverlapCircleAll(attackZone.position, 0.1f);

                foreach (Collider2D hit in hits) {
                    ObstacleFlower obs = hit.GetComponent<ObstacleFlower>();
                    RewardFlower rwds = hit.GetComponent<RewardFlower>();

                    if (obs) {      // Hit obsticle, kill vine
                        if (Input.GetKeyDown(keyAttack)) {
                            SoundManager.instance.PlaySoundKill();
                            obs.Break();
                        }
                    }
                    if(rwds) {      // Hit flower, add score
                        if (Input.GetKeyDown(keyAttack)) {
                            SoundManager.instance.PlaySoundScore();
                            rwds.Break();
                            GameScore.instance.EarnPoints(rwds.rewardS);
                            PlayerPrefs.SetInt("Score", GameScore.instance.score);
                        }
                    }

                }
            }
        }

        void LateUpdate() {
            for (int i = 0; i < sprites.Length; i++) {
                if (_spriteRenderer.sprite == sprites[i]) {
                    facingDirection = (Direction)i;
                    break;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D other) {
            // Hit by vine
            if (other.gameObject.GetComponent<ObstacleFlower>()) {
                SoundManager.instance.PlaySoundHitByVine();
                TakeDamage(1);
            }
            if (GameScore.instance.score >= ReachGoal.instance.goalScore
                && other.gameObject.GetComponent<ReachGoal>()) {
                // SoundManager.instance.Play
                print("Success!");
                //_rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
                TimePause();
                _levelDialog.Success();
            }

        }

        // void OnTriggerEnter2D(Collider2D other) {
        //     if (other.gameObject.GetComponent<ReachGoal>()) {
        //         if(Input.GetKeyDown(keyAttack)) {
        //             if(GameScore.instance.score >= ReachGoal.instance.goalScore) {
        //                 print("Success!");
        //                 _rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        //             }
        //         }
        //     }
        // }

        void Die() {
            SoundManager.instance.PlaySoundGameOver();
            _animator.SetTrigger("die");
            //_rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
            TimePause();
            _levelDialog.Fail();

        }

        void TakeDamage(int damageAmount) {
            health -= damageAmount;
            if (health <= 0) {
                health = 0;
                Die();
                Debug.Log("You're dead");
            }
            heart.SetHeartImage((HeartStatus)health);
        }

        void TimePause() {
            Time.timeScale = 0;
        }

        void TimeUnpause() {
            Time.timeScale = 1;
        }
    }
}

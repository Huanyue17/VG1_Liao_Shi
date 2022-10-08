using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace level1 {
    public enum HeartStatus {
        Empty = 0,
        Quarter = 1,
        Half = 2,
        ThreeQuarter = 3,
        Full = 4
    }

    public class HealthHeart : MonoBehaviour {
        public Sprite fullHeart, threeQtrHeart, halfHeart, qtrHeart, emptyHeart;
        Image heartImage;

        private void Awake() {
            heartImage = GetComponent<Image>();
        }

        public void SetHeartImage(HeartStatus status) {
            switch (status) {
                case HeartStatus.Full:
                    heartImage.sprite = fullHeart;
                    break;
                case HeartStatus.ThreeQuarter:
                    heartImage.sprite = threeQtrHeart;
                    break;
                case HeartStatus.Half:
                    heartImage.sprite = halfHeart;
                    break;
                case HeartStatus.Quarter:
                    heartImage.sprite = qtrHeart;
                    break;
                case HeartStatus.Empty:
                    heartImage.sprite = emptyHeart;
                    break;
            }
        }
    }
}


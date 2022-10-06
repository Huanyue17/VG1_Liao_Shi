using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace level1 {

    public class CameraController : MonoBehaviour
    {
        public Transform target;
        // Start is called before the first frame update

        public Vector3 offset;
        public float smoothness;


        Vector3 _velocity;
        void Start()
        {
            if (target) {
                offset = transform.position - target.position;
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (target) {
                transform.position = Vector3.SmoothDamp(
                    transform.position,
                    target.position + offset,
                    ref _velocity,
                    smoothness
                );
            }
        }
    }
}

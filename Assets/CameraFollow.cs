using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   
        
        public Transform target;
        public Vector3 offset;
        public float smoothSpeed = 0.125f;

        void Start()
        {
            // Calculate initial offset if not set in Inspector
            if (target != null && offset == Vector3.zero)
                offset = transform.position - target.position;
        }

        void LateUpdate()
        {
            Vector3 desiredPosition = target.position + offset;
            // Smoothly interpolate to the target position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
}

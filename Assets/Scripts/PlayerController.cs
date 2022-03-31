
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Ingame{
    public class PlayerController : MonoBehaviour
    {
        private int count= 0;
        private Rigidbody rb;
        private float movementX, movementY;
        public float speed;
        
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }
        
        void OnMove(InputValue movementValue)
        {
            Vector2 movementVector = movementValue.Get<Vector2>();
            movementX = movementVector.x;
            movementY = movementVector.y;
        }

        private void FixedUpdate()
        {
            Vector3 movement = new Vector3(movementX, 0f, movementY);
            rb.AddForce(movement*speed);
        }
        
        IEnumerator OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("PickUp"))
            {
                other.gameObject.SetActive(false);
                count++; // 먹은 개수 증가시키기 
            }

            yield return null;
        }
    }
}

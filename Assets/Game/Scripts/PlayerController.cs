using System;
using UnityEngine;
using UnityEngine.UI;

namespace FG
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Tooltip("Base speed value of the vertical movement")]
        public float verticalSpeed;
        [Tooltip("Base speed value of the horizontal movement")]
        public float horizontalSpeed;
        //[Tooltip("Base speed value of the rotation of the player following the mouse")]
        //public float rotationSpeed;
        [Tooltip("The player's max hp")]
        public int hp = 20;
        [Tooltip("The text component displaying player's hp")]
        public Text hpText;
        [Tooltip("The text component displaying player's points")]
        public Text pointsText;
        [Tooltip("The gameObject with the text component that reads game over")]
        public GameObject gameOver;

        [NonSerialized] public int points = 0; // The points the player has gathered
        private float verticalInput; // Storage for input "Vertical" in the input manager
        private float horizontalInput; // Storage for input "Horizontal" in the input manager
        private Transform playerTransform; // The transform component of this gameobject
        private Vector3 lookDirection; // Vector for direction to point at
        private Rigidbody2D rb; // this.Rigidbody2D
        private Camera mainCamera;
        private float angle; // angle to calculate for Player Rotation
        private Quaternion quaternionAngle; // Conversion to quaternion and in the correct format for application

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
            playerTransform = GetComponent<Transform>();
            mainCamera = Camera.main;
        }
        private void Update()
        {
            lookDirection = Input.mousePosition - mainCamera.WorldToScreenPoint(playerTransform.position);
            angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            playerTransform.rotation  = quaternionAngle = Quaternion.AngleAxis(angle - 90, Vector3.forward);

             //= Quaternion.Slerp(playerTransform.rotation, quaternionAngle, 1 - Mathf.Exp(rotationSpeed * Time.deltaTime));

            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");

            pointsText.text = $"Points: {points}";
            hpText.text = $"Lives: {hp}";
            if(hp <= 0)
            {
                gameOver.SetActive(true);
                hpText.gameObject.SetActive(false);
                Destroy(this.gameObject);
            }
        }
        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontalInput * horizontalSpeed, verticalInput * verticalSpeed);
        }
    }
}

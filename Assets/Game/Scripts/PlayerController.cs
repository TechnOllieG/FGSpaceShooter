using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float verticalSpeed; // Base speed value of the vertical movement
    [SerializeField] private float horizontalSpeed; // Base speed value of the horizontal movement
    [SerializeField] private float rotationSpeed; // Base speed value of the rotation of the player following the mouse


    private float verticalInput; // Storage for input "Vertical" in the input manager
    private float horizontalInput; // Storage for input "Horizontal" in the input manager
    private Transform playerTransform; // The transform component of this gameobject
    private Vector3 lookDirection;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float angle;
    private Quaternion quaternionAngle;
    
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

        quaternionAngle = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, quaternionAngle, 1 - Mathf.Exp(rotationSpeed * Time.deltaTime));

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * horizontalSpeed, verticalInput * verticalSpeed);
    }
}

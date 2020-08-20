using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float verticalSpeed; // Base speed value of the vertical movement
    public float horizontalSpeed; // Base speed value of the horizontal movement
    public float rotationSpeed; // Base speed value of the rotation of the player following the mouse

    private float verticalInput; // Storage for input "Vertical" in the input manager
    private float horizontalInput; // Storage for input "Horizontal" in the input manager
    private Transform playerTransform; // The transform component of this gameobject
    private Vector3 lookDirection;
    private Quaternion lookRotation;
    private Rigidbody2D rb;
    private Camera mainCamera;
    public Vector3 mousePosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        mainCamera = Camera.main;
    }
    private void Update()
    {


        lookDirection = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle -90, Vector3.forward);


        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(horizontalInput * horizontalSpeed * Time.fixedDeltaTime, verticalInput * verticalSpeed * Time.fixedDeltaTime, 0));
    }
}

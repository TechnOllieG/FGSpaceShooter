using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody2D rb;
    private Transform playerTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
    }
    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        playerTransform.position = playerTransform.position + new Vector3(horizontalInput*horizontalSpeed*Time.fixedDeltaTime, verticalInput*verticalSpeed*Time.fixedDeltaTime, 0);
    }
}

using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float verticalSpeed;
    public float horizontalSpeed;

    private float verticalInput;
    private float horizontalInput;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rb.AddForce(new Vector2(horizontalInput*horizontalSpeed, verticalInput*verticalSpeed));
    }
}

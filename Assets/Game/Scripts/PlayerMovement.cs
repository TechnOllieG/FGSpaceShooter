using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float forwardInput;

    private void FixedUpdate()
    {
        Input.GetAxis("Vertical");
    }
}

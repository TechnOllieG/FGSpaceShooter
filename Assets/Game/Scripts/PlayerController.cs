using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float verticalSpeed; // Base speed value of the vertical movement
    [SerializeField] private float horizontalSpeed; // Base speed value of the horizontal movement
    [SerializeField] private float rotationSpeed; // Base speed value of the rotation of the player following the mouse
    [SerializeField] private float machineGunAmmoSpeed;
    [SerializeField] private float machineGunCooldown;
    [SerializeField] private GameObject machineGunAmmo;
    [SerializeField] private GameObject machineGun1;
    [SerializeField] private GameObject machineGun2;

    private float verticalInput; // Storage for input "Vertical" in the input manager
    private float horizontalInput; // Storage for input "Horizontal" in the input manager
    private Transform playerTransform; // The transform component of this gameobject
    private Vector3 lookDirection;
    private Rigidbody2D rb;
    private Camera mainCamera;
    private float angle;
    private Quaternion quaternionAngle;
    private GameObject machineGunAmmoClone1;
    private GameObject machineGunAmmoClone2;
    private float currentMachineGunCooldown = 0;

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

        if (Input.GetMouseButtonDown(0) && currentMachineGunCooldown == 0)
        {
            machineGunAmmoClone1 = Instantiate(machineGunAmmo, machineGun1.transform, false);
            machineGunAmmoClone2 = Instantiate(machineGunAmmo, machineGun2.transform, false);

            machineGunAmmoClone1.transform.SetParent(null);
            machineGunAmmoClone2.transform.SetParent(null);

            machineGunAmmoClone1.GetComponent<Rigidbody2D>().AddForce((lookDirection - playerTransform.position) * machineGunAmmoSpeed);
            machineGunAmmoClone2.GetComponent<Rigidbody2D>().AddForce((lookDirection - playerTransform.position) * machineGunAmmoSpeed);
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * horizontalSpeed, verticalInput * verticalSpeed);
    }
}

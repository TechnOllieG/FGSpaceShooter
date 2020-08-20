using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float machineGunCooldown;
    public GameObject MachineGunAmmo;
    public Transform LeftGunTransform;
    public Transform RightGunTransform;
    public float ShootCooldown;

    private float currentMachineGunCooldown = 0;


    private Quaternion dirQuaternion;

    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        currentMachineGunCooldown -= Time.deltaTime;
        if (Input.GetMouseButton(0) && currentMachineGunCooldown <= 0)
        {

            dirQuaternion = transform.rotation;
            Instantiate(MachineGunAmmo, LeftGunTransform.position, dirQuaternion);
            Instantiate(MachineGunAmmo, RightGunTransform.position, dirQuaternion);

            currentMachineGunCooldown = ShootCooldown;
        }



    }
}
